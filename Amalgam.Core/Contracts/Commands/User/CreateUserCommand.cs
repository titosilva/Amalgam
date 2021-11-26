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
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email).EmailAddress().Length(0, Constants.EmailMaxLength);
            RuleFor(u => u.Password).MinimumLength(User.PasswordMinLen);
            RuleFor(u => u.Role).Length(0, User.RoleMaxLen);
        }
    }

    public class CreateUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public bool IsValid
            => new CreateUserCommandValidator().Validate(this).IsValid;

        public List<ValidationFailure> Errors
            => new CreateUserCommandValidator().Validate(this).Errors;

        public void EnsureIsValid()
        {
            if (!IsValid)
            {
                throw DomainValidationException.Of(Errors);
            }
        }
    }
}
