using System.Collections.Generic;
using Amalgam.App.HttpApi.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Amalgam.App.HttpApi.Controllers.Base
{
    public abstract class HttpApiControllerBase : ControllerBase
    {
        protected virtual ApiResult Success(string message = null)
            => new ApiResult(true, message);

        protected virtual ApiResult Fail(string message = null)
            => new ApiResult(false, message);

        protected virtual ApiResult<TData> Success<TData>(string message = null) where TData : class
            => new ApiResult<TData>(true, message, null);

        protected virtual ApiResult<TData> Fail<TData>(string message = null) where TData : class
            => new ApiResult<TData>(false, message, null);

        protected virtual ApiResult<TData> SuccessWithData<TData>(TData data, string message = null)
            => new ApiResult<TData>(true, message, data);

        protected virtual ApiResult<TData> FailWithData<TData>(TData data, string message = null)
            => new ApiResult<TData>(false, message, data);
    }   
}