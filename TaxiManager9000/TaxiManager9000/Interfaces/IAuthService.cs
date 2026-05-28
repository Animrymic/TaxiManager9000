using TaxiManager9000.Models;

namespace TaxiManager9000.Interfaces;

public interface IAuthService
{
    User Login(string username, string password);

    void Logout();

    User GetCurrentUser(); 
}
