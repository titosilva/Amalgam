using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Contracts.Handlers
{
    public interface IUserHandler
    {
        Task<User> CreateUserAsync(CreateUserCommand command);
        Task<(LoginResults Result, User User)> LoginAsync(LoginCommand command, string roleIfFirst);
    }
}
