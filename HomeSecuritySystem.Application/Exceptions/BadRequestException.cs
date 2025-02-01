 using FluentValidation.Results;

namespace HomeSecuritySystem.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base($"Entity \"{message}\" was BadRequest Message")
        {

        } 
        
        public BadRequestException(string message,ValidationResult validationResult)
            : base($"Entity \"{message}\" was BadRequest Message")
        {
            ValidationErrors = new();
            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }


        public List<string> ValidationErrors  { get; set; }
    }
}
