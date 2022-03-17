


namespace Shared.Models
{
    public class UserCredentials
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserCredentials(in string name, in string password)
        {
            Name = name;
            Password = password;
        }
    }
}