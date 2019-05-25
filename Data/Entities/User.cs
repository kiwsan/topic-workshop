using Data.Utils;

namespace Data.Entities
{
    public class User
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("username")]
        public string UserName { get; set; }
        [Name("password")]
        public string Password { get; set; }
        [Name("email")]
        public string Email { get; set; }
        [Name("display_name")]
        public string DisplayName { get; set; }
    }
}