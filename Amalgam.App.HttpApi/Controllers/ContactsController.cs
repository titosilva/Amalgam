using Amalgam.App.HttpApi.Controllers.Base;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Contracts.Handlers;
using Amalgam.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amalgam.App.HttpApi.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    [AllowAnonymous]
    public class ContactsController : HttpApiControllerBase
    {
        private readonly IContactHandler contactHandler;
        private readonly AmalgamContext context;

        public ContactsController(IContactHandler contactHandler, AmalgamContext context)
        {
            this.contactHandler = contactHandler;
            this.context = context;
        }

        [HttpPost]
        public async Task CreateContact(CreateContactCommand command)
        {
            contactHandler.CreateContact(command);
            await context.SaveChangesAsync();
        }
    }
}
