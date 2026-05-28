using TaxiManager9000.Data;
using TaxiManager9000.Enums;
using TaxiManager9000.Interfaces;
using TaxiManager9000.Models;

namespace TaxiManager9000.Services;

public class UserService : IUserService
{
    public void CreateUser(string username, string password, Role role)
    {
        if(string.IsNullOrWhiteSpace(username) || username.Length < 5)
        {
            Console.WriteLine("Username must be at least 5 characters.");
            return;
        }

        if (string.IsNullOrWhiteSpace(password) || password.Length < 5 || !password.Any(char.IsDigit))
        {
            Console.WriteLine("Password must be at least 5 characters and contain a number.");
            return;
        }

        int newId = DataStore.Users.Count + 1;

        var user = new User(newId, username, password, role); 

        DataStore.Users.Add(user);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"User {username} created successfully as {role}");
        Console.ResetColor();
    }

    public void DeleteUser(int id)
    {
        var user = DataStore.Users.FirstOrDefault(u => u.Id == id); 

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        DataStore.Users.Remove(user); 

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"User {user.Username} deleted.");
        Console.ResetColor();
    }

    public List<User> GetAllUsers()
    {
        return DataStore.Users;
    }
}
