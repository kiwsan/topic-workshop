using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Data.Entities;
using Data.Interfaces;
using Data.Utils;

namespace Data.Repositories
{
    public class CommentRepository : IDisposable, ICommentRepository
    {
        private readonly DbContext _context;

        public CommentRepository()
        {
            _context = new DbContext(AppConstants.ConnectionString);
        }

        public IEnumerable<Comment> FindByPostId(int postId)
        {
            return _context.ExecuteProc<Comment>("commentpFindByPostId", new SqlParameter("@postId", postId));
        }

        public Comment Add(Comment comment)
        {
            _context.ExecuteProc<object>("commentpAdd", new SqlParameter("@content", comment.Content),
                new SqlParameter("@authorId", comment.AuthorId),
                new SqlParameter("@statusId", comment.StatusId),
                new SqlParameter("@url", comment.Url),
                new SqlParameter("@postId", comment.PostId),
                new SqlParameter("@createdDate", DateTime.Now),
                new SqlParameter("@updatedDate", DateTime.Now));

            return comment;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}