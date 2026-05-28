using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using TaxiManager9000.Enums; 
namespace TaxiManager9000.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public User()
    {
    }

    public User(int id, string username, string password, Role role)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
    }
}
