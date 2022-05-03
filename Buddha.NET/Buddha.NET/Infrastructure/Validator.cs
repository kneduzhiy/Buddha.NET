using Buddha.NET.Helper;
using Buddha.NET.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buddha.NET
{
    public class Validator<TRequest> where TRequest : class
    {
        protected virtual IList<ValidationConstraint<TRequest>> Constraints { get; private set; }
        protected virtual Task<IList<ValidationConstraint<TRequest>>> OnValidate() => null;

        public async Task<ValidationResult<TRequest>> Validate(TRequest request)
        {
            var failedConstraints = new List<ValidationConstraint<TRequest>>();

            if (Constraints is null)
            {
                Constraints = await OnValidate();
            }

            foreach (var constraint in Constraints)
            {
                var valid = await constraint.ValidateFunc(request);
                if (!valid)
                {
                    constraint.Property = constraint.PropertyFunc?.GetMemberName();
                    constraint.ErrorMessage = constraint.ErrorMessageFunc(request);
                    failedConstraints.Add(constraint);
                }
            }

            return new()
            {
                ValidationFailed = failedConstraints.Count > 0,
                FailedValidationItems = failedConstraints
            };
        }

        public Response<TResponse> GenerateErrorResponse<TResponse>(List<ValidationConstraint<TRequest>> failedValidationConstraints) where TResponse : class
        {
            if (failedValidationConstraints.Count == 0)
            {
                throw new("Tried to generate error response although no validation constraint failed");
            }

            return new()
            {
                HttpStatusCode = 400,
                Success = false,
                Error = new ErrorData
                {
                    Message = "Validation errors occured",
                    Data = failedValidationConstraints.Select(_ => new ErrorItem
                    {
                        Message = _.ErrorMessage,
                        Field = _?.Property
                    })
                }
            };
        }
    }
}
