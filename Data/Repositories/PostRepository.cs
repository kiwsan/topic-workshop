using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Data.Entities;
using Data.Utils;

namespace Data.Repositories
{
    public class PostRepository: IDisposable
    {
        private readonly DbContext _context;

        public PostRepository()
        {
            _context = new DbContext(AppConstants.ConnectionString);
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.ExecuteProc<Post>("postpGetAll", null);
        }

        public Post FindById(int id)
        {
            return _context.ExecuteProc<Post>("postpFindById", new SqlParameter("@id", id)).FirstOrDefault();
        }

        public Post Add(Post post)
        {
            _context.ExecuteProc<object>("postpAdd", new SqlParameter("@title", post.Title),
                new SqlParameter("@content", post.Content),
                new SqlParameter("@authorId", post.AuthorId),
                new SqlParameter("@statusId", post.StatusId),
                new SqlParameter("@createdDate", DateTime.Now),
                new SqlParameter("@updatedDate", DateTime.Now),
                new SqlParameter("@isPublished", true));

            return post;
        }

        public void Unpublished(int id, bool isPublished)
        {
            _context.ExecuteProc<object>("postpIsPublished", new SqlParameter("@id", id),
                new SqlParameter("@isPublished", isPublished));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}