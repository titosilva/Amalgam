using Amalgam.Core.Classes;
using Amalgam.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Entities
{
    public class User : Entity
    {
        public const int RoleMaxLen = 20;
        public const int PasswordMinLen = 8;

        public User() : base()
        {
        }

        public User(string email, string role) : base()
        {
            Email = email;
            Role = role;
        }

        [Required, MaxLength(Constants.EmailMaxLength)]
        public string Email { get; private set; }

        [Required, MaxLength(Constants.PasswordHashLength)]
        public string PasswordHash { get; private set; }

        [Required, MaxLength(RoleMaxLen)]
        public string Role { get; private set; }

        #region Setters
        public void SetPassword(string password, IPasswordHashService passwordHashService)
            => PasswordHash = passwordHashService.HashPassword(password);

        #endregion
    }
}
