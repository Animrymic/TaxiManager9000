using TaxiManager9000.Helpers;
using TaxiManager9000.Interfaces;
using TaxiManager9000.Enums;

namespace TaxiManager9000.Menus;

public class AdminMenu
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public AdminMenu(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService; 
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== ADMIN MENU ===");
            Console.WriteLine("1) Create User");
            Console.WriteLine("2) Delete User");
            Console.WriteLine("3) List Users");
            Console.WriteLine("4) Change Password");
            Console.WriteLine("5) Logout");
            Console.WriteLine("6) Back");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateUser();
                    break;
                case "2":
                    DeleteUser();
                    break;
                case "3":
                    ListUsers();
                    break;
                case "4":
                    ChangePassword();
                    break;
                case "5":
                    _authService.Logout();
                    return;
                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid option!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CreateUser()
    {
        Console.Clear();
        Console.WriteLine("=== CREATE USER ===");

        string username = InputHelper.ReadRequiredString("Username: ");
        string password = InputHelper.ReadRequiredString("Password: ");

        int roleChoice = InputHelper.ReadMenuChoice(
            "Role 1) Admin, 2) Manager, 3) Maintenance: ", 1, 3);

        Role role = roleChoice switch
        {
            1 => Role.Administrator,
            2 => Role.Manager,
            3 => Role.Maintenance
        };

        _userService.CreateUser(username, password, role);

        Console.ReadKey(); 
    }

    private void DeleteUser()
    {
        Console.Clear();
        Console.WriteLine("=== DELETE USER ===");

        int id = InputHelper.ReadInt("Enter User ID: ");

        _userService.DeleteUser(id); 

        Console.ReadKey(); 
    }

    private void ListUsers()
    {
        Console.Clear();
        Console.WriteLine("=== USERS ===");

        var users = _userService.GetAllUsers();

        foreach (var u in users)
        {
            Console.WriteLine($"{u.Id}) {u.Username} - {u.Role}");
        }

        Console.ReadKey(); 
    }

    private void ChangePassword()
    {
        Console.Clear();
        Console.WriteLine("=== CHANGE PASSWORD ===");

        var user = _authService.GetCurrentUser(); 

        if(user == null)
        {
            Console.WriteLine("No user logged in.");
            Console.ReadKey();
            return; 
        }

        string oldPass = InputHelper.ReadRequiredString("Old Password: "); 

        if (oldPass != user.Password)
        {
            Console.WriteLine("Incorrect password!");
            Console.ReadKey();
            return;
        }

        string newPass = InputHelper.ReadRequiredString("New Password: ");

        user.Password = newPass;

        Console.WriteLine("Password changed successfully!");
        Console.ReadKey(); 
    }
}
