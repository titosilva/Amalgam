using System;
using System.Threading.Tasks;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Contracts.Handlers;
using Amalgam.Core.Contracts.Repositories;
using Amalgam.Core.Entities;
using Amalgam.Core.Exceptions;

namespace Amalgam.Core.Handlers
{
    public class GiftHandler : IGiftHandler
    {
        private readonly IGiftRepository giftRepository;

        public GiftHandler(IGiftRepository giftRepository)
        {
            this.giftRepository = giftRepository;
        }

        public Gift CreateGift(CreateGiftCommand command)
        {
            command.EnsureIsValid();

            var gift = new Gift(command.Title, command.Value, command.ImageUrl, command.Description);
            gift.AddMultipleLinks(command.Links);
            giftRepository.AddGift(gift);

            return gift;
        }


        public async Task<Gift> UpdateGiftAsync(Guid id, UpdateGiftCommand command)
        {
            command.EnsureIsValid();

            var gift = await giftRepository.GetRequiredGift(id);

            if (gift.IsDeleted)
            {
                throw new DomainRuleException("Can't update already deleted gift");
            }

            gift.SetTitle(command.Title);
            gift.SetValue(command.Value);
            gift.SetImageUrl(command.ImageUrl);
            gift.SetDescription(command.Description);
            gift.ClearLinks();
            gift.AddMultipleLinks(command.Links);

            giftRepository.UpdateGift(gift);
            return gift;
        }

        public async Task DeleteGiftAsync(Guid id)
        {
            var gift = await giftRepository.GetRequiredGift(id);

            if (gift.IsDeleted)
            {
                throw new DomainRuleException("Can't delete already deleted gift");
            }

            gift.SetDateDeleted(DateTimeOffset.Now);
            giftRepository.UpdateGift(gift);
        }
    }
}