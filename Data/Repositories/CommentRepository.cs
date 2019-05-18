using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Topic.Models;
using Topic.Utils;

namespace Topic.Data.Repositories
{
    public class CommentRepository : IDisposable
    {
        private readonly DbContext _context;

        public CommentRepository()
        {
            _context = new DbContext(AppConstants.ConnectionString);
        }

        public IEnumerable<Comment> GetFindByPostId(int postId)
            => _context.ExecuteProc<Comment>("commentpFindByPostId", new SqlParameter("@postId", postId));

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