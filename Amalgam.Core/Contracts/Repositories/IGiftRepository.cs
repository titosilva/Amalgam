using System;
using System.Threading.Tasks;
using Amalgam.Core.Entities;

namespace Amalgam.Core.Contracts.Repositories
{
    public interface IGiftRepository
    {
        Task<Gift> GetGift(Guid giftId);
        Task<Gift> GetRequiredGift(Guid giftId);
        void AddGift(Gift gift);
        void UpdateGift(Gift gift);
    }
}