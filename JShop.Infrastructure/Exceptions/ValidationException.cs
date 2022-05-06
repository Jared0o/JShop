using FluentValidation.Results;

namespace JShop.Infrastructure.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public int ErrorCount { get; set; }
        public List<string> Errors { get; set; }
        public ValidationException(ValidationResult validationResult)
        {
            ErrorCount = validationResult.Errors.Count;
            Errors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }

        }
    }
}
