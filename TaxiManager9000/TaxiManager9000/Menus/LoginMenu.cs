using TaxiManager9000.Services;
using TaxiManager9000.Interfaces;

namespace TaxiManager9000.Menus;

public class LoginMenu
{
    private readonly IAuthService _authService;

    public LoginMenu(IAuthService authService)
    {
        _authService = authService;
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Taxi Manager 9000 ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: "); 
            string password = Console.ReadLine();

            var user = _authService.Login(username, password);

            if (user != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Login Successful! Welcome {user.Role}");
                Console.ResetColor();

                break; 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login failed! Try again.");
                Console.ResetColor();

                Console.ReadKey();
            }
        }
    }
}
