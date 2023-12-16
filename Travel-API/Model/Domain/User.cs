using System.ComponentModel.DataAnnotations;

namespace Travel_API.UserModel.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

    }
}
