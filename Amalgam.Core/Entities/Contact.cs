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

        public Contact(string name, string mobile) : base()
        {
            Name = name;
            Mobile = mobile;
        }

        [Required, MaxLength(NameMaxLen)]
        public string Name { get; private set; }

        [Required, MaxLength(Constants.MobileMaxLength)]
        public string Mobile { get; private set; }
    }
}
