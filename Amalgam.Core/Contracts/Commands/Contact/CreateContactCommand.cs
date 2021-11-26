using Amalgam.Core.Classes;
using Amalgam.Core.Entities;
using Amalgam.Core.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Contracts.Commands
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(c => c.Name).Length(0, Contact.NameMaxLen);
            RuleFor(c => c.Value).Length(0, Constants.EmailMaxLength);
        }
    }

    public class CreateContactCommand
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ContactTypes Type { get; set; }

        public bool IsValid
          => new CreateContactCommandValidator().Validate(this).IsValid;

        public List<ValidationFailure> Errors
            => new CreateContactCommandValidator().Validate(this).Errors;

        public void EnsureIsValid()
        {
            if (!IsValid)
            {
                throw DomainValidationException.Of(Errors);
            }
        }
    }
}
