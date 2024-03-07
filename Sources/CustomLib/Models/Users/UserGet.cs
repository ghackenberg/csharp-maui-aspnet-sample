namespace CustomLib.Models.Users
{
    public class UserGet : UserPost
    {
        public string UserId { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}
