using System.Threading.Tasks;
using Amalgam.Core.Commands;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Entities;

namespace Amalgam.Core.Contracts.Handlers
{
    public interface IGuestHandler {
        Task<Guest> AddGuest(AddGuestCommand command);
        Task<Guest> UpdateGuest(UpdateGuestCommand command);
    }
}