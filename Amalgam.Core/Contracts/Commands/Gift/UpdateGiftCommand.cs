using System;

namespace Amalgam.Core.Contracts.Commands
{
    public class UpdateGiftCommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Value { get; set; }
    }
}