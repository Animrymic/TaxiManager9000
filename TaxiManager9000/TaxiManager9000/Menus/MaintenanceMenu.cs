using TaxiManager9000.Interfaces;
using TaxiManager9000.Services;

namespace TaxiManager9000.Menus; 

public class MaintenanceMenu
{
    private readonly ICarService _carService;

    public MaintenanceMenu(ICarService carService)
    {
        _carService = carService;
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MAINTENANCE MENU ===");
            Console.WriteLine("1) List all vehicles");
            Console.WriteLine("2) Show license status");
            Console.WriteLine("3) Show operational vehicles");
            Console.WriteLine("4) Back");
            Console.Write("Select option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListAllVehicles();
                    break;

                case "2":
                    ShowLicenseStatus();
                    break;

                case "3":
                    ShowOperationalVehicles();
                    break;

                case "4":
                    return;
                    

                default:
                    Console.WriteLine("Invalid option");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ListAllVehicles()
    {
        var cars = _carService.GetAllCars();

        Console.Clear();
        Console.WriteLine("=== ALL VEHICLES ===");

        foreach (var car in cars)
        {
            double util = _carService.CalculateUtilization(car);
            string status = _carService.GetCarStatus(car);

            Console.WriteLine(
                $"{car.Id}) {car.Model} | Plate: {car.LicensePlate} | Utilization: {util:0}% | Status: {status}"
            );
        }

        Console.ReadKey();
    }

    private void ShowLicenseStatus()
    {
        var cars = _carService.GetAllCars();

        Console.Clear();
        Console.WriteLine("=== LICENSE STATUS ===");

        foreach (var car in cars)
        {
            string status = _carService.GetCarStatus(car);

            Console.WriteLine(
                $"{status} Car {car.Model} ({car.LicensePlate}) - Exp: {car.LicenseExpiryDate.ToShortDateString()}"
            );
        }

        Console.ReadKey();
    }

    private void ShowOperationalVehicles()
    {
        var cars = _carService.GetOperationalCars();

        Console.Clear();
        Console.WriteLine("=== OPERATIONAL VEHICLES ===");

        foreach (var car in cars)
        {
            double util = _carService.CalculateUtilization(car);

            Console.WriteLine(
                $"{car.Id}) {car.Model} | Plate: {car.LicensePlate} | Utilization: {util:0}%"
            );
        }

        Console.ReadKey();
    }
}
