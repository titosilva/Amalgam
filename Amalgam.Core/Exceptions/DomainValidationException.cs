using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Amalgam.Core.Exceptions
{
    public class DomainValidationException : Exception
    {
        public static DomainValidationException Of(List<ValidationFailure> errors)
            => new DomainValidationException(errors, "Erro de validação");

        public DomainValidationException(List<ValidationFailure> errors)
        {
            Errors = errors;
        }

        public DomainValidationException(List<ValidationFailure> errors, string message) : base(message)
        {
            Errors = errors;
        }

        public DomainValidationException(List<ValidationFailure> errors, string message, Exception innerException) 
            : base(message, innerException)
        {
            Errors = errors;
        }

        public List<ValidationFailure> Errors { get; set; }
    }
}