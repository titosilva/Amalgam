using System;
using System.Threading.Tasks;
using Amalgam.Core.Entities;

namespace Amalgam.Core.Contracts.Repositories
{
    public interface IGuestRepository
    {
        Task<Guest> GetGuest(Guid guestId);
        Task<Guest> GetRequiredGuest(Guid guestId);
        void AddGuest(Guest guest);
        void UpdateGuest(Guest guest);
    }
}