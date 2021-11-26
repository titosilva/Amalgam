using Amalgam.Core.Contracts.Repositories;
using Amalgam.Core.Entities;
using Amalgam.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AmalgamContext context;

        public ContactRepository(AmalgamContext context)
        {
            this.context = context;
        }

        public IQueryable<Contact> Contacts
            => context.Contacts;

        public void AddContact(Contact contact)
            => context.Add(contact);
    }
}
