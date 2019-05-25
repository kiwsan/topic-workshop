using System;
using Data.Enums;

namespace Application.Models.Responses
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public EStatusType StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int AuthorId { get; set; }
        public string Url { get; set; }
        public int PostId { get; set; }
    }
}