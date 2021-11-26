using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Contracts.Handlers
{
    public interface IContactHandler
    {
        Contact CreateContact(CreateContactCommand command);
    }
}
