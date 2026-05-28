using TaxiManager9000.Interfaces;
using TaxiManager9000.Data;
using TaxiManager9000.Models;

namespace TaxiManager9000.Services;

public class AuthService : IAuthService
{
    private User _currentUser; 

    public User Login(string username, string password)
    {
        var user = DataStore.Users
            .FirstOrDefault(u => u.Username == username && u.Password == password); 

        if(user != null)
        {
            _currentUser = user; 
            return user;
        }

        return null; 
    }

    public void Logout()
    {
        _currentUser = null; 
    }

    public User GetCurrentUser()
    {
        return _currentUser;
    }


}
