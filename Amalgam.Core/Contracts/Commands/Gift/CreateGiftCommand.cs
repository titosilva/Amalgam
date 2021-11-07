using System.Collections.Generic;
using Amalgam.Core.Classes;
using Amalgam.Core.Entities;
using Amalgam.Core.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace Amalgam.Core.Contracts.Commands
{
    public class CreateGiftCommandValidator : AbstractValidator<CreateGiftCommand>
    {
        public CreateGiftCommandValidator()
        {
            RuleFor(c => c.Title).Length(0, Gift.TitleMaxLen).NotEmpty();
            RuleFor(c => c.ImageUrl).Length(0, Constants.UrlMaxLength);
            RuleFor(c => c.Value).GreaterThan(0);
        }
    }

    public class CreateGiftCommand {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Value { get; set; }

        public bool IsValid
            => new CreateGiftCommandValidator().Validate(this).IsValid;
        
        public List<ValidationFailure> Errors
            => new CreateGiftCommandValidator().Validate(this).Errors;

        public void EnsureIsValid()
        {
            if (!IsValid)
            {
                throw DomainValidationException.Of(Errors);
            }
        }
    }
}