using System;
using System.Linq;
using System.Linq.Expressions;

namespace GuildENM.Models.Repositories
{
    public interface IPostRepository : IDisposable
    {
        IQueryable<Post> All { get; }
        IQueryable<Post> AllIncluding(params Expression<Func<Post, object>>[] includeProperties);
        Post Find(int id);
        void InsertOrUpdate(Post post);
        void Delete(int id);
        void Save();
    }
}