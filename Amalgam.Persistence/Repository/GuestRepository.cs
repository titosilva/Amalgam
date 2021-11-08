using System;
using System.Linq;
using System.Threading.Tasks;
using Amalgam.Core.Entities;
using Amalgam.Core.Exceptions;
using Amalgam.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Amalgam.Core.Contracts.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly AmalgamContext context;

        public GuestRepository(AmalgamContext context)
            => this.context = context;

        public IQueryable<Guest> AllGuests => context.Guests.AsNoTracking();

        public void AddGuest(Guest guest)
            => context.Guests.Add(guest);

        public Task<Guest> GetGuest(Guid guestId)
            => AllGuests.FirstOrDefaultAsync(g => g.Id == guestId);

        public async Task<Guest> GetRequiredGuest(Guid guestId)
            => await GetGuest(guestId) ?? throw NotFoundException.Of("Convidado");

        public void UpdateGuest(Guest guest)
            => context.Guests.Attach(guest).State = EntityState.Modified;
    }
}