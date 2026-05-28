using TaxiManager9000.Interfaces;
using TaxiManager9000.Menus;

namespace TaxiManager9000.App; 

public class AppController
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IDriverService _driverService;
    private readonly ICarService _carService; 

    public AppController(IAuthService authService, IUserService userService, IDriverService driverService, ICarService carService)
    {
        _authService = authService;
        _userService = userService;
        _driverService = driverService;
        _carService = carService;
    }

    public void Run()
    {
        while (true)
        {
            var loginMenu = new LoginMenu(_authService);
            loginMenu.Show();

            var router = new MenuRouter(_authService, _userService, _driverService, _carService);
            router.Start();
        }
    }


}
