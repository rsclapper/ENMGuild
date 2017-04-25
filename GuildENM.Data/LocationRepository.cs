using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GuildENM.Models;
using GuildENM.Models.Repositories;

namespace GuildENM.Data
{ 
    public class LocationRepository : ILocationRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Location> All
        {
            get { return context.Locations; }
        }

        public IQueryable<Location> AllIncluding(params Expression<Func<Location, object>>[] includeProperties)
        {
            IQueryable<Location> query = context.Locations;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Location Find(int id)
        {
            return context.Locations.Find(id);
        }

        public void InsertOrUpdate(Location location)
        {
            if (location.Id == default(int)) {
                // New entity
                context.Locations.Add(location);
            } else {
                // Existing entity
                context.Entry(location).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var location = context.Locations.Find(id);
            context.Locations.Remove(location);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }
}