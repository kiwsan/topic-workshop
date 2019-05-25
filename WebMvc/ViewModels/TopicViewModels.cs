using System.Collections.Generic;
using Application.Models.Responses;

namespace WebMvc.ViewModels
{
    public class TopicViewModels
    {
        public IEnumerable<PostResponse> Posts { get; set; }
    }
}