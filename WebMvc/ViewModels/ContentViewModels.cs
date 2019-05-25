using System.Collections.Generic;
using Application.Models.Responses;

namespace WebMvc.ViewModels
{
    public class ContentViewModels
    {
        public PostResponse Post { get; set; }
        public IEnumerable<CommentResponse> Comments { get; set; }
    }
}