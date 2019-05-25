using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class CreateCommentRequest
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}