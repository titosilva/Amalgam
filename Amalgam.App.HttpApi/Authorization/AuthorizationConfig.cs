using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amalgam.App.HttpApi.Authorization
{
    public class AuthorizationConfig
    {
        public string Secret { get; set; }

        public int TokenValidityMinutes { get; set; } = 60;
    }
}
