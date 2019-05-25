using System.Collections.Generic;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post FindById(int id);
        Post Add(Post post);
        void Unpublished(int id, bool isPublished);
    }
}