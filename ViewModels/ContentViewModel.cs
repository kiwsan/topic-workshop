using System.Collections.Generic;
using Topic.Models;
using Topic.ViewModels.Requests;

namespace Topic.ViewModels
{
    public class ContentViewModel : User
    {
        public Post Post { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}