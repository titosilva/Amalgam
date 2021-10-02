using System;
using System.Threading.Tasks;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Entities;

namespace Amalgam.Core.Contracts.Handlers
{
    public interface IGiftHandler {
        Task<Gift> CreateGift(CreateGiftCommand command);
        Task<Gift> UpdateGift(UpdateGiftCommand command);
        Task DeleteGift(Guid id);
    }
}