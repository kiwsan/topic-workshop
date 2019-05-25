using System.Collections.Generic;
using Data.Entities;

namespace Data.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> FindByPostId(int postId);
        Comment Add(Comment comment);
    }
}