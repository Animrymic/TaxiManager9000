using TaxiManager9000.App;
using TaxiManager9000.Data;
using TaxiManager9000.Interfaces;
using TaxiManager9000.Menus;
using TaxiManager9000.Services;

MockUsers.Seed();
MockDrivers.Seed();
MockCars.Seed();
MockAssignments.Seed();

var authService = new AuthService();
var userService = new UserService();
var driverService = new DriverService();
var carService = new CarService();

var app = new AppController(
    authService,
    userService,
    driverService,
    carService
);

app.Run();