using Amalgam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Contracts.Repositories
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
    }
}
