namespace BackendAPI.Models
{
    /// <summary>
    /// Represents a user of the application. This simple POCO class defines
    /// properties that map to columns in the Users database table. A nullable
    /// ImageUrl is used to store the URI of the uploaded image in Blob Storage.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}