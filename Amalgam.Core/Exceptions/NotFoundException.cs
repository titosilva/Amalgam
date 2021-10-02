using System;

namespace Amalgam.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public static NotFoundException Of(string name)
            => new NotFoundException($"{name} não encontrado");

        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}