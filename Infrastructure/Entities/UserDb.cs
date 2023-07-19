namespace Infrastructure.Entities;

public class UserDb
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? LastModified { get; set; }

    public UserDb(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
        Created = DateTime.Now;
    }
}
