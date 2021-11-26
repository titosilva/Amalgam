using Amalgam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailOrDefaultAsync(string email);
        void AddUser(User user);
        Task<bool> AnyUserAsync();
    }
}
