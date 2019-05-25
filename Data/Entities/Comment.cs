using System;
using Data.Enums;
using Data.Utils;

namespace Data.Entities
{
    public class Comment
    {
        [Name("id")]
        public int Id { get; set; }
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
        [Name("url")]
        public string Url { get; set; }
        [Name("post_id")]
        public int PostId { get; set; }
    }
}