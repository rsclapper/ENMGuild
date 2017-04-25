using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GuildENM.Models;
using GuildENM.Models.Repositories;

namespace GuildENM.Data
{ 
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
            foreach (var includeProperty in includeProperties) {
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
            if (company.Id == default(int)) {
                // New entity
                context.Companies.Add(company);
            } else {
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
}