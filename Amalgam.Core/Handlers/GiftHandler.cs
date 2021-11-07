using System;
using System.Threading.Tasks;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Contracts.Handlers;
using Amalgam.Core.Contracts.Repositories;
using Amalgam.Core.Entities;

namespace Amalgam.Core.Handlers
{
    public class GiftHandler : IGiftHandler
    {
        private readonly IGiftRepository giftRepository;

        public GiftHandler(IGiftRepository giftRepository)
        {
            this.giftRepository = giftRepository;
        }

        public Task<Gift> CreateGiftAsync(CreateGiftCommand command)
        => Task.Run(() =>
        {
            var gift = new Gift(command.Title, command.Value, command.ImageUrl);
            giftRepository.AddGift(gift);
            return gift;
        });


        public async Task<Gift> UpdateGiftAsync(UpdateGiftCommand command)
        {
            var gift = await giftRepository.GetRequiredGift(command.Id);

            gift.SetTitle(command.Title);
            gift.SetValue(command.Value);
            gift.SetImageUrl(command.ImageUrl);

            giftRepository.UpdateGift(gift);
            return gift;
        }

        public async Task DeleteGiftAsync(Guid id)
        {
            var gift = await giftRepository.GetRequiredGift(id);
            gift.SetDateDeleted(DateTimeOffset.Now);
            giftRepository.UpdateGift(gift);
        }
    }
}