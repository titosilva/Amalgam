using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Contracts.Services
{
    public interface IPasswordHashService
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string passwordHash, string providedValue);
    }
}
