namespace Core.Entities
{
    public class User
    {
        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}