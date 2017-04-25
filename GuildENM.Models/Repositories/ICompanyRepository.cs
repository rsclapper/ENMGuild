using System;
using System.Linq;
using System.Linq.Expressions;

namespace GuildENM.Models.Repositories
{
    public interface ICompanyRepository : IDisposable
    {
        IQueryable<Company> All { get; }
        IQueryable<Company> AllIncluding(params Expression<Func<Company, object>>[] includeProperties);
        Company Find(int id);
        void InsertOrUpdate(Company company);
        void Delete(int id);
        void Save();
    }
}