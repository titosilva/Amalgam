using System;
using System.Threading;
using System.Threading.Tasks;

namespace Amalgam.App.HttpApi.Models
{
    public class ApiResult<TData>
    {
        public ApiResult(bool success, string message, TData data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
    }
}