using System.Collections.Generic;
using Topic.Models;

namespace Topic.ViewModels
{
    public class TopicViewModel : User
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}