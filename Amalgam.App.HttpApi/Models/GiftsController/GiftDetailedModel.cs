using Amalgam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amalgam.App.HttpApi.Models.GiftsController
{
    public class GiftDetailedModel : GiftModel
    {
        public string Description { get; set; }
        public List<GiftLink> Links { get; set; }
    }
}
