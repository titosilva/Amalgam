using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amalgam.App.HttpApi.Authorization;
using Amalgam.App.HttpApi.Controllers.Base;
using Amalgam.App.HttpApi.Models;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Contracts.Handlers;
using Amalgam.Core.Contracts.Repositories;
using Amalgam.Core.Entities;
using Amalgam.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amalgam.App.HttpApi.Controllers
{
    [Route("api/gifts")]
    [ApiController]
    [Authorize(Roles = Roles.Owner)]
    public class GiftsController : HttpApiControllerBase
    {
        private readonly IGiftRepository _giftRepository;
        private readonly IGiftHandler _giftHandler;
        private readonly AmalgamContext _context;

        public GiftsController(
            IGiftRepository giftRepository,
            IGiftHandler giftHandler,
            AmalgamContext context)
        {
            _giftRepository = giftRepository;
            _giftHandler = giftHandler;
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ApiResult<List<Gift>>> ListGiftsPaginated([FromQuery] ApiPaginatedQueryParams parameters)
            => parameters.Q > 0? 
                SuccessWithData(await _giftRepository.GetGiftsPaginated(parameters.ToQueryParams())) : 
                Fail<List<Gift>>("Quantity must be greater than 1");

        [HttpPost]
        public async Task<ApiResult<Gift>> CreateGift([FromBody] CreateGiftCommand command)
        {
            command.EnsureIsValid();

            var gift = _giftHandler.CreateGift(command);
            await _context.SaveChangesAsync();

            return SuccessWithData(gift, "Gift created successfully");
        }

        [HttpPut("{id}")]
        public async Task<ApiResult<Gift>> UpdateGift([FromRoute] Guid id, [FromBody] UpdateGiftCommand command)
        {
            command.EnsureIsValid();

            var gift = await _giftHandler.UpdateGiftAsync(id, command);
            await _context.SaveChangesAsync();

            return SuccessWithData(gift, "Gift updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> DeleteGift([FromRoute] Guid id)
        {
            await _giftHandler.DeleteGiftAsync(id);
            return Success("Gift deleted successfully");
        }
    }
}