using System.Collections.Generic;

namespace Buddha.NET.Model
{
    public class ValidationResult<TRequest> where TRequest : class
    {
        public bool ValidationFailed { get; set; }
        public List<ValidationConstraint<TRequest>> FailedValidationItems { get; set; }
    }
}
