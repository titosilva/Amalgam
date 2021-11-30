using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Amalgam.Core.Exceptions
{
    public class DomainValidationException : Exception
    {
        public static DomainValidationException Of(List<ValidationFailure> errors)
            => new DomainValidationException(errors, "Validation errors");

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

        public override string ToString()
        {
            return $"{base.ToString()} - Errors: {string.Join("; ", Errors.Select(e => e.ToString()).ToList())}";
        }
    }
}