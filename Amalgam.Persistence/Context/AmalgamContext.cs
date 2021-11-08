using Amalgam.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amalgam.Persistence.Context
{
    public class AmalgamContext : DbContext
    {
        public AmalgamContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Gift> Gifts { get; set;  }
        public DbSet<Guest> Guests { get; set;  }
        public DbSet<GuestGroup> GuestGroups { get; set;  }
    }
}