using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amalgam.App.HttpApi.Models.GiftsController
{
    public class GiftModel
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
