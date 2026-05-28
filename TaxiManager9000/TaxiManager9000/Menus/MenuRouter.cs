using TaxiManager9000.Enums;
using TaxiManager9000.Helpers;
using TaxiManager9000.Interfaces;

namespace TaxiManager9000.Menus;

public class MenuRouter
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService; 
    private readonly IDriverService _driverService;
    private readonly ICarService _carService;

    public MenuRouter(IAuthService authService, IUserService userService, IDriverService driverService, ICarService carService)
    {
        _authService = authService;
        _userService = userService;
        _driverService = driverService;
        _carService = carService;
    }
    public MenuRouter(IAuthService authService)
    {
        _authService = authService;
    }

    public void Start()
    {
        var user = _authService.GetCurrentUser();

        if (user == null)
        {
            Console.WriteLine("No user logged in.");
            return;
        }

        switch (user.Role)
        {
            case Role.Administrator:
                ShowAdminMenu();
                break;

            case Role.Manager:
                ShowManagerMenu();
                break;

            case Role.Maintenance:
                ShowMaintenanceMenu();
                break;
        }
    }

    private void ShowAdminMenu()
    {
        var adminMenu = new AdminMenu(_userService, _authService);
        adminMenu.Show();
    }

    private void ShowManagerMenu()
    {
        var managerMenu = new DriverMenu(_driverService);
        managerMenu.Show();
    }

    private void ShowMaintenanceMenu()
    {
        var maintenanceMenu = new MaintenanceMenu(_carService);

        maintenanceMenu.Show(); 
    }
}