using Amalgam.Core.Entities;
using Amalgam.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Amalgam.App.HttpApi.Context
{
    public class AppDbContext : DbContext, IAmalgamContext
    {
        public DbSet<Gift> Gifts { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<GuestGroup> GuestGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
