using Amalgam.App.HttpApi.Authorization;
using Amalgam.App.HttpApi.Controllers.Base;
using Amalgam.App.HttpApi.Models;
using Amalgam.App.HttpApi.Models.User;
using Amalgam.Core.Classes;
using Amalgam.Core.Contracts.Commands;
using Amalgam.Core.Contracts.Handlers;
using Amalgam.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amalgam.App.HttpApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : HttpApiControllerBase
    {
        private readonly IUserHandler _userHandler;
        private readonly TokenService tokenService;
        private readonly AmalgamContext context;

        public UsersController(IUserHandler userHandler, TokenService tokenService, AmalgamContext context)
        {
            _userHandler = userHandler;
            this.tokenService = tokenService;
            this.context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ApiResult<LoginResult>> LoginAsync(LoginCommand command)
        {
            var (loginResult, user) = await _userHandler.LoginAsync(command, Roles.Owner);

            var result = new LoginResult()
            {
                Result = loginResult,
                Token = loginResult == LoginResults.Success ? tokenService.GenerateToken(user.Id, user.Role) : null,
            };

            await context.SaveChangesAsync();

            return loginResult == LoginResults.Success ? SuccessWithData(result, "Successful login!") : FailWithData(result);
        }
    }
}
