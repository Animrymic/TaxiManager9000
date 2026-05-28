using TaxiManager9000.Enums;
using TaxiManager9000.Models;

namespace TaxiManager9000.Interfaces;

public interface IUserService
{
    void CreateUser(string username, string password, Role role);
    void DeleteUser(int id);
    List<User> GetAllUsers();
}
