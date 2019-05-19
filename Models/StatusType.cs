using Topic.Utils;

namespace Topic.Models
{
    public class StatusType
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("name")]
        public string Name { get; set; }
    }
}