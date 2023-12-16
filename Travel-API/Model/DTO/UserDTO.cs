using System.ComponentModel.DataAnnotations;

namespace Travel_API.UserModel.DTO
{
    public class UserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string[]? Roles { get; set; }
    }
}
