using System.ComponentModel.DataAnnotations;

namespace Amalgam.Core.Entities
{
    public class Guest : Entity
    {
        public const int NameMaxLen = 200;

        public Guest() : base() { }

        public Guest(string name) : base() 
        {
            Name = name;
        }

        [MaxLength(NameMaxLen)]
        public string Name { get; private set; }

        public void SetName(string name) => Name = name;
    }
}