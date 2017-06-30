using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GuildENM.Models;
using GuildENM.Models.Repositories;

namespace GuildENM.Data
{

    public class Uow : IDisposable
    {
        public EFRepository<Post> Posts { get; set; }
        public EFRepository<Location> Locations { get; set; }
        public EFRepository<Company> Companies { get; set; }
        public EFRepository<Contact> Contacts { get; set; }
        public EFRepository<Skill> Tags { get; set; }
        private readonly ApplicationDbContext _ctx;

        public Uow()
        {
            _ctx = new ApplicationDbContext();
            this.Posts = new EFRepository<Post>(_ctx);
            this.Locations = new EFRepository<Location>(_ctx);
            this.Companies = new EFRepository<Company>(_ctx);
            this.Contacts = new EFRepository<Contact>(_ctx);
            this.Tags = new EFRepository<Skill>(_ctx);
        }
        public void Save()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
    public class CompanyRepository : ICompanyRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Company> All
        {
            get { return context.Companies; }
        }

        public IQueryable<Company> AllIncluding(params Expression<Func<Company, object>>[] includeProperties)
        {
            IQueryable<Company> query = context.Companies;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Company Find(int id)
        {
            return context.Companies.Find(id);
        }

        public void InsertOrUpdate(Company company)
        {
            if (company.Id == default(int))
            {
                // New entity
                context.Companies.Add(company);
            }
            else
            {
                // Existing entity
                context.Entry(company).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var company = context.Companies.Find(id);
            context.Companies.Remove(company);
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

    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void InsertOrUpdate(T company);
        void Delete(int id);
        void Save();
    }

    public class EFRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _context;
        public EFRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public IQueryable<T> All
        {
            get
            {
                IQueryable<T> query = _context.Set<T>();
                return query;
            }

        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public T Find(int id)
        {
            IQueryable<T> query = _context.Set<T>();
            return query.FirstOrDefault(a => a.Id == id);
        }

        public void InsertOrUpdate(T entity)
        {
            if (entity.Id == default(int))
            {
                // New entity
                _context.Set<T>().Add(entity);
            }
            else
            {
                // Existing entity
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var company = _context.Companies.Find(id);
            _context.Companies.Remove(company);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}