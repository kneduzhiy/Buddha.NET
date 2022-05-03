using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Buddha.NET.Model
{
    public class ValidationConstraint<T>
    {
        public Func<T, Task<bool>> ValidateFunc { get; set; }
        public Func<T, string> ErrorMessageFunc { get; set; }
        public Expression<Func<T, object>> PropertyFunc { get; set; }

        public string Property { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public ValidationConstraint(Func<T, Task<bool>> validate, Func<T, string> errorMessage, Expression<Func<T, object>> property = null)
        {
            ValidateFunc = validate;
            PropertyFunc = property;
            ErrorMessageFunc = errorMessage;
        }
    }
}
