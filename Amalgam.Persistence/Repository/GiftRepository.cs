using System;
using System.Linq;
using System.Threading.Tasks;
using Amalgam.Core.Entities;
using Amalgam.Core.Exceptions;
using Amalgam.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Amalgam.Core.Contracts.Repositories
{
    public class GiftRepository : IGiftRepository
    {
        private readonly IAmalgamContext context;

        public GiftRepository(IAmalgamContext context)
            => this.context = context;

        public IQueryable<Gift> AllGifts => context.Gifts.AsNoTracking();

        public IQueryable<Gift> Gifts => AllGifts.Where(g => g.DateDeleted != null);

        public void AddGift(Gift gift)
            => context.Gifts.Add(gift);

        public Task<Gift> GetGift(Guid giftId)
            => Gifts.FirstOrDefaultAsync(g => g.Id == giftId);

        public async Task<Gift> GetRequiredGift(Guid giftId)
            => await GetGift(giftId) ?? throw NotFoundException.Of("Presente");

        public void UpdateGift(Gift gift)
            => context.Gifts.Attach(gift).State = EntityState.Modified;
    }
}