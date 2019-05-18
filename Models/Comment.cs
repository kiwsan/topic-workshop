using System;

namespace Topic.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Status StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int AuthorId { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public int PostId { get; set; }
    }

    public enum Status
    {
        User = 1,
        Admin,
        Author
    }
}