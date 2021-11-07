using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amalgam.App.HttpApi.Context;
using Amalgam.App.HttpApi.Controllers.Base;
using Amalgam.App.HttpApi.Models;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Contracts.Handlers;
using Amalgam.Core.Contracts.Repositories;
using Amalgam.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Amalgam.App.HttpApi.Controllers
{
    [Route("api/gifts")]
    [ApiController]
    public class GiftsController : HttpApiControllerBase
    {
        private readonly IGiftRepository _giftRepository;
        private readonly IGiftHandler _giftHandler;
        private readonly AppDbContext _appDbContext;

        public GiftsController(
            IGiftRepository giftRepository,
            IGiftHandler giftHandler,
            AppDbContext appDbContext)
        {
            _giftRepository = giftRepository;
            _giftHandler = giftHandler;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ApiResult<List<Gift>>> ListGiftsPaginated([FromQuery] ApiPaginatedQueryParams parameters)
            => Success(await _giftRepository.GetGiftsPaginated(parameters.ToQueryParams()));

        [HttpPost]
        public async Task<ApiResult<Gift>> CreateGift([FromBody] CreateGiftCommand command)
        {
            command.EnsureIsValid();

            var gift = await _giftHandler.CreateGiftAsync(command);
            await _appDbContext.SaveChangesAsync();

            return Success(gift, "Gift created successfully");
        }
    }
}