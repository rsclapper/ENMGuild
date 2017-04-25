using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GuildENM.Models;
using GuildENM.Models.Repositories;

namespace GuildENM.Data
{ 
    public class PostRepository : IPostRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Post> All
        {
            get { return context.Posts; }
        }

        public IQueryable<Post> AllIncluding(params Expression<Func<Post, object>>[] includeProperties)
        {
            IQueryable<Post> query = context.Posts;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Post Find(int id)
        {
            return context.Posts.Find(id);
        }

        public void InsertOrUpdate(Post post)
        {
            if (post.Id == default(int)) {
                // New entity
                context.Posts.Add(post);
            } else {
                // Existing entity
                context.Entry(post).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var post = context.Posts.Find(id);
            context.Posts.Remove(post);
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