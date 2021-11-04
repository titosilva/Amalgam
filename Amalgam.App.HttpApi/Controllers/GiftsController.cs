using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amalgam.App.HttpApi.Controllers.Base;
using Amalgam.App.HttpApi.Models;
using Amalgam.Core.Contracts.Commands;
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

        public GiftsController(IGiftRepository giftRepository)
        {
            this._giftRepository = giftRepository;
        }

        [HttpGet]
        public async Task<ApiResult<List<Gift>>> ListGiftsPaginated([FromQuery] ApiPaginatedQueryParams parameters)
            => Success(await _giftRepository.GetGiftsPaginated(parameters.ToQueryParams()));

        [HttpPost]
        public async Task<ApiResult<Gift>> CreateGift([FromBody] CreateGiftCommand command)
        {
            if (!command.IsValid)
            {
                return Invalid(command.Errors, "command");
            }
        }
    }
}