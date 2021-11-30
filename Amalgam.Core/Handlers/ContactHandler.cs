using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Contracts.Handlers;
using Amalgam.Core.Contracts.Repositories;
using Amalgam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Handlers
{
    public class ContactHandler : IContactHandler
    {
        private readonly IContactRepository contactRepository;

        public ContactHandler(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public Contact CreateContact(CreateContactCommand command)
        {
            command.EnsureIsValid();

            var contact = new Contact(command.Name, command.Mobile);
            contactRepository.AddContact(contact);

            return contact;
        }
    }
}
