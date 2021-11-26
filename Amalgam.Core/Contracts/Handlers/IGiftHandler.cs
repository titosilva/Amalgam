using System;
using System.Threading.Tasks;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Entities;

namespace Amalgam.Core.Contracts.Handlers
{
    public interface IGiftHandler {
        Gift CreateGift(CreateGiftCommand command);
        Task<Gift> UpdateGiftAsync(Guid id, UpdateGiftCommand command);
        Task DeleteGiftAsync(Guid id);
    }
}