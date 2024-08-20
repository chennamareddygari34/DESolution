namespace DEApp.Models.DTOs
{
    public class ProfileSettingDTO
    {
        public int UserId { get; set; }

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string MobileNumber { get; set; } = null!;
        public int RoleId { get; set; }


    }
}
