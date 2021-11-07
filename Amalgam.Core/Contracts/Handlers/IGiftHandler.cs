using System;
using System.Threading.Tasks;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Entities;

namespace Amalgam.Core.Contracts.Handlers
{
    public interface IGiftHandler {
        Task<Gift> CreateGiftAsync(CreateGiftCommand command);
        Task<Gift> UpdateGiftAsync(UpdateGiftCommand command);
        Task DeleteGiftAsync(Guid id);
    }
}