using System.Collections.Generic;
using Amalgam.App.HttpApi.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Amalgam.App.HttpApi.Controllers.Base
{
    public abstract class HttpApiControllerBase : ControllerBase
    {
        protected virtual ApiResult<TData> Success<TData>(TData data, string message = null)
            => new ApiResult<TData>(true, message, data);

        protected virtual ApiResult<TData> Fail<TData>(TData data, string message = null)
            => new ApiResult<TData>(false, message, data);
    }   
}