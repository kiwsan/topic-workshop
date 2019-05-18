using System.Collections.Generic;
using Topic.Models;

namespace Topic.ViewModels
{
    public class ContentViewModel : User
    {
        public Post Post { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}