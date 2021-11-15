using System;
using System.Threading;
using System.Threading.Tasks;

namespace Amalgam.App.HttpApi.Models
{
    public class ApiResult
    {
        public ApiResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ApiResult<TData> : ApiResult
    {
        public ApiResult(bool success, string message, TData data) : base(success, message)
        {
            Data = data;
        }

        public TData Data { get; set; }
    }
}