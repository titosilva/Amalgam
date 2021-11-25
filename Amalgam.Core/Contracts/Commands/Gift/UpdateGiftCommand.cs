using Amalgam.Core.Classes;
using Amalgam.Core.Entities;
using Amalgam.Core.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Amalgam.Core.Contracts.Commands
{
    public class UpdateGiftCommandValidator : AbstractValidator<UpdateGiftCommand>
    {
        public UpdateGiftCommandValidator()
        {
            RuleFor(c => c.Title).Length(0, Gift.NameMaxLen).NotEmpty();
            RuleFor(c => c.ImageUrl).Length(0, Constants.UrlMaxLength);
            RuleFor(c => c.Value).GreaterThan(0);
        }
    }

    public class UpdateGiftCommand
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Value { get; set; }

        public bool IsValid
            => new UpdateGiftCommandValidator().Validate(this).IsValid;

        public List<ValidationFailure> Errors
            => new UpdateGiftCommandValidator().Validate(this).Errors;

        public void EnsureIsValid()
        {
            if (!IsValid)
            {
                throw DomainValidationException.Of(Errors);
            }
        }
    }
}