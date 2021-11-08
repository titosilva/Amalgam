using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amalgam.Core.Contracts.Repositories.Parameters;
using Amalgam.Core.Entities;
using Amalgam.Core.Exceptions;
using Amalgam.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Amalgam.Core.Contracts.Repositories
{
    public class GiftRepository : IGiftRepository
    {
        private readonly AmalgamContext _context;

        public GiftRepository(AmalgamContext context)
            => _context = context;

        public IQueryable<Gift> AllGifts => _context.Gifts.AsNoTracking();

        public IQueryable<Gift> Gifts => AllGifts.Where(g => g.DateDeleted != null);

        public Task<List<Gift>> GetGiftsPaginated(PaginatedQueryParams parameters)
            => Gifts.Skip(parameters.Offset).Take(parameters.Quantity).ToListAsync();

        public void AddGift(Gift gift)
            => _context.Gifts.Add(gift);

        public Task<Gift> GetGift(Guid giftId)
            => Gifts.FirstOrDefaultAsync(g => g.Id == giftId);

        public async Task<Gift> GetRequiredGift(Guid giftId)
            => await GetGift(giftId) ?? throw NotFoundException.Of("Presente");

        public void UpdateGift(Gift gift)
            => _context.Gifts.Attach(gift).State = EntityState.Modified;
    }
}