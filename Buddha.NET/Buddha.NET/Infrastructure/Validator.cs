using Buddha.NET.Model;
using System.Collections.Generic;
using System.Linq;

namespace Buddha.NET
{
    public class Validator<TRequest> where TRequest : class
    {
        protected virtual IList<ValidationConstraint<TRequest>> Constraints { get; }

        public ValidationResult<TRequest> Validate(TRequest request)
        {
            var failedConstraints = new List<ValidationConstraint<TRequest>>();

            foreach (var constraint in Constraints)
            {
                var valid = constraint.ValidateFunc(request);
                if (!valid)
                {
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
                Success = false,
                Error = new ErrorData
                {
                    Message = "Validation errors occured",
                    Data = failedValidationConstraints.Select(_ => new
                    {
                        Message = _.ErrorMessage
                    })
                }
            };
        }
    }
}
