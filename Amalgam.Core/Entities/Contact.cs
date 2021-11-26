using Amalgam.Core.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgam.Core.Entities
{
    public enum ContactTypes
    {
        Email = 1,
        Mobile
    }

    public class Contact : Entity
    {
        public const int NameMaxLen = 200;

        public Contact() : base()
        {
        }

        public Contact(ContactTypes type, string name, string value) : base()
        {
            Type = type;
            Name = name;
            Value = value;
        }

        public Contact(string type, string name, string value) : base()
        {
            ContactTypeName = type;
            Name = name;
            Value = value;
        }

        [MaxLength(NameMaxLen)]
        public string Name { get; private set; }

        [NotMapped]
        public ContactTypes Type { get; private set; }

        [MaxLength(10)]
        public string ContactTypeName
        {
            get => Enum.GetName(Type);
            set => Type = Enum.Parse<ContactTypes>(value);
        }

        [MaxLength(Constants.EmailMaxLength)]
        public string Value { get; private set; }
    }
}
