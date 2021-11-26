using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Contracts.Handlers;
using Amalgam.Core.Contracts.Repositories;
using Amalgam.Core.Contracts.Services;
using Amalgam.Core.Entities;
using Amalgam.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Handlers
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService passwordHashService;

        public UserHandler(IUserRepository userRepository, IPasswordHashService passwordHashService)
        {
            _userRepository = userRepository;
            this.passwordHashService = passwordHashService;
        }

        public async Task<User> CreateUserAsync(CreateUserCommand command)
        {
            command.EnsureIsValid();

            var alreadyExistingUser = await _userRepository.GetUserByEmailOrDefaultAsync(command.Email);

            if (alreadyExistingUser != null)
            {
                throw new DomainRuleException($"An user with the email {command.Email} already exists");
            }

            var user = new User(command.Email, command.Role);
            user.SetPassword(command.Password, passwordHashService);

            _userRepository.AddUser(user);

            return user;
        }

        public async Task<(LoginResults Result, User User)> LoginAsync(LoginCommand command, string roleIfFirst)
        {
            var user = await _userRepository.GetUserByEmailOrDefaultAsync(command.Email);
            
            if (user == null)
            {
                if (await _userRepository.AnyUserAsync())
                {
                    return (LoginResults.NotIdentified, null);
                } else
                {
                    return (LoginResults.Success, await CreateUserAsync(new CreateUserCommand()
                    {
                        Email = command.Email,
                        Password = command.Password,
                        Role = roleIfFirst,
                    }));
                }
            }

            if (!passwordHashService.VerifyPassword(user.PasswordHash, command.Password))
            {
                return (LoginResults.WrongPassword, null);
            }

            return (LoginResults.Success, user);
        }
    }
}
