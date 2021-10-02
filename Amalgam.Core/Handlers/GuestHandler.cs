using System.Threading.Tasks;
using Amalgam.Core.Commands;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Contracts.Handlers;
using Amalgam.Core.Contracts.Repositories;
using Amalgam.Core.Entities;

namespace Amalgam.Core.Handlers
{
    public class GuestHandler : IGuestHandler
    {
        private readonly IGuestRepository guestRepository;

        public GuestHandler(IGuestRepository guestRepository)
        {
            this.guestRepository = guestRepository;
        }

        public Task<Guest> AddGuest(AddGuestCommand command)
        => Task.Run(() =>
        {
            var guest = new Guest(command.Name);
            guestRepository.AddGuest(guest);
            return guest;
        });

        public async Task<Guest> UpdateGuest(UpdateGuestCommand command)
        {
            var guest = await guestRepository.GetRequiredGuest(command.Id);
            guest.SetName(command.Name);
            guestRepository.UpdateGuest(guest);
            return guest;
        }
    }
}