using Amalgam.Core.Contracts.Repositories;
using Amalgam.Core.Entities;
using Amalgam.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AmalgamContext context;

        public UserRepository(AmalgamContext context)
        {
            this.context = context;
        }

        public IQueryable<User> Users
            => context.Users;

        public void AddUser(User user)
            => context.Add(user);

        public Task<bool> AnyUserAsync()
            => Users.AnyAsync();

        public Task<User> GetUserByEmailOrDefaultAsync(string email)
            => Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
