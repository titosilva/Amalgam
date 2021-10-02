namespace Amalgam.Core.Contracts.Commands
{
    public class CreateGiftCommand {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Value { get; set; }
    }
}