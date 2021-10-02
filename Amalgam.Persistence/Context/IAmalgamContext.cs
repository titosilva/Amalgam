using Amalgam.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amalgam.Persistence.Context
{
    public interface IAmalgamContext
    {
        DbSet<Gift> Gifts { get; }
        DbSet<Guest> Guests { get; }
        DbSet<GuestGroup> GuestGroups { get; }
    }
}