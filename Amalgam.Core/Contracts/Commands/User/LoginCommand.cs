using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Contracts.Commands
{
    public enum LoginResults
    {
        Success = 1,
        WrongPassword,
        NotIdentified,
    }

    public class LoginCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
