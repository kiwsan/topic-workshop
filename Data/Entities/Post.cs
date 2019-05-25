using System;
using Data.Enums;
using Data.Utils;

namespace Data.Entities
{
    public class Post
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("title")]
        public string Title { get; set; }
        [Name("content")]
        public string Content { get; set; }
        [Name("status_id")]
        public EStatusType StatusId { get; set; }
        [Name("created_date")]
        public DateTime CreatedDate { get; set; }
        [Name("updated_date")]
        public DateTime UpdatedDate { get; set; }
        [Name("author_id")]
        public int AuthorId { get; set; }
        [Name("is_published")]
        public bool IsPublished { get; set; }
    }
}