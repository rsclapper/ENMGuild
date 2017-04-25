using System;
using System.Linq;
using System.Linq.Expressions;

namespace GuildENM.Models.Repositories
{
    public interface ILocationRepository : IDisposable
    {
        IQueryable<Location> All { get; }
        IQueryable<Location> AllIncluding(params Expression<Func<Location, object>>[] includeProperties);
        Location Find(int id);
        void InsertOrUpdate(Location location);
        void Delete(int id);
        void Save();
    }
}