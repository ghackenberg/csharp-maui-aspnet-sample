namespace CustomLib.Models.Users
{
    public class UserRead : UserCreate
    {
        public string UserId { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}
