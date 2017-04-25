using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using GuildENM.Models;
using GuildENM.Models.Repositories;

namespace GuildENM.Data
{ 
    public class CommentRepository : ICommentRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Comment> All
        {
            get { return context.Comments; }
        }

        public IQueryable<Comment> AllIncluding(params Expression<Func<Comment, object>>[] includeProperties)
        {
            IQueryable<Comment> query = context.Comments;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Comment Find(int id)
        {
            return context.Comments.Find(id);
        }

        public void InsertOrUpdate(Comment comment)
        {
            if (comment.Id == default(int)) {
                // New entity
                context.Comments.Add(comment);
            } else {
                // Existing entity
                context.Entry(comment).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var comment = context.Comments.Find(id);
            context.Comments.Remove(comment);
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