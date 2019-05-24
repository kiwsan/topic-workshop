using Topic.Models;

namespace Topic.ViewModels.Requests
{
    public class CreatePostRequest: Post
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
    }
}