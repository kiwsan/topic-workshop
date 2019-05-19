using System;
using System.ComponentModel.DataAnnotations;
using Topic.Utils;

namespace Topic.Models
{
    public class Post
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("title")]
        [Required]
        public string Title { get; set; }
        [Name("content")]
        [Required]
        public string Content { get; set; }
        [Name("status_id")]
        public Status StatusId { get; set; }
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