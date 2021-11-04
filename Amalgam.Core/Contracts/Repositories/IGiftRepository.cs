using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amalgam.Core.Contracts.Repositories.Parameters;
using Amalgam.Core.Entities;

namespace Amalgam.Core.Contracts.Repositories
{
    public interface IGiftRepository
    {
        Task<Gift> GetGift(Guid giftId);
        Task<Gift> GetRequiredGift(Guid giftId);
        Task<List<Gift>> GetGiftsPaginated(PaginatedQueryParams parameters);
        void AddGift(Gift gift);
        void UpdateGift(Gift gift);
    }
}