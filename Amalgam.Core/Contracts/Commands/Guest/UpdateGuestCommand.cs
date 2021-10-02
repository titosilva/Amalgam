using System;

namespace Amalgam.Core.Contracts.Commands
{
    public class UpdateGuestCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}