


using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class UserCredentials
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(15)]
        public string Name { get; set; }
        [Required, MaxLength(15)]
        public string Password { get; set; }
        public UserCredentials(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}