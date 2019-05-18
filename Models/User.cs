using Topic.Utils;

namespace Topic.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Name("display_name")]
        public string DisplayName { get; set; }
    }
}