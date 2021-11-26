using Amalgam.Core.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amalgam.App.HttpApi.Models.User
{
    public class LoginResult
    {
        public LoginResults Result { get; set; }
        public string Token { get; set; }
    }
}
