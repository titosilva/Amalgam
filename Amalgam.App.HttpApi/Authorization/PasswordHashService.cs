using Amalgam.Core.Contracts.Services;
using Amalgam.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.App.HttpApi.Authorization
{
    public class PasswordHashService : IPasswordHashService
    {
        private readonly SHA256 sha256;

        public PasswordHashService()
        {
            this.sha256 = SHA256.Create();
        }

        public string HashPassword(string password)
            => Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));

        public bool VerifyPassword(string passwordHash, string providedValue)
            => HashPassword(providedValue) == passwordHash;
    }
}
