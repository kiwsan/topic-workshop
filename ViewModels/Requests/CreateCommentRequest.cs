using System.ComponentModel.DataAnnotations;

namespace Topic.ViewModels.Requests
{
    public class CreateCommentRequest
    {
        [Required] 
        public string Content { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}