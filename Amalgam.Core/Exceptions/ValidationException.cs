using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Amalgam.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public static ValidationException Of(List<ValidationFailure> errors)
            => new ValidationException(errors, "Erro de validação");

        public ValidationException(List<ValidationFailure> errors)
        {
            Errors = errors;
        }

        public ValidationException(List<ValidationFailure> errors, string message) : base(message)
        {
            Errors = errors;
        }

        public ValidationException(List<ValidationFailure> errors, string message, Exception innerException) : base(
            message, innerException)
        {
            Errors = errors;
        }
        
        public List<ValidationFailure> Errors { get; set; }
    }
}