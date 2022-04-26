using System;

namespace Buddha.NET.Model
{
    public class ValidationConstraint<T>
    {
        public Func<T, bool> ValidateFunc { get; set; }
        public Func<T, string> ErrorMessageFunc { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public ValidationConstraint(Func<T, bool> validate, Func<T, string> errorMessage)
        {
            ValidateFunc = validate;
            ErrorMessageFunc = errorMessage;
        }
    }
}
