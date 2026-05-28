using TaxiManager9000.Interfaces;
using TaxiManager9000.Enums;
using TaxiManager9000.Helpers;

namespace TaxiManager9000.Menus;

public class DriverMenu
{
    private readonly IDriverService _driverService;

    public DriverMenu(IDriverService driverService)
    {
        _driverService = driverService;
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== DRIVER MANAGEMENT ===");
            Console.WriteLine("1) List all drivers");
            Console.WriteLine("2) List all unassigned drivers");
            Console.WriteLine("3) Assign driver");
            Console.WriteLine("4) Unassign driver");
            Console.WriteLine("5) View assignments");
            Console.WriteLine("6) Back");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();

            switch (input)
            {

                case "1":
                    ListAllDrivers();
                    break;
                case "2":
                    ListUnassignedDrivers();
                    break;
                case "3":
                    AssignDriver();
                    break;
                case "4":
                    UnassignDriver();
                    break;
                case "5":
                    ViewAssignments();
                    break;
                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid option!");
                    Console.ReadKey();
                    break;
            }

        }
    }

    private void ListAllDrivers()
    {
        var drivers = _driverService.GetAllDrivers();

        Console.Clear();
        Console.WriteLine("=== ALL DRIVERS ===");

        foreach (var d in drivers)
        {
            Console.WriteLine($"{d.Id}) {d.FirstName} {d.LastName} - {d.Shift} - Exp: {d.LicenseExpiryDate.ToShortDateString()}");
        }

        Console.ReadKey();
    }

    private void ListUnassignedDrivers()
    {
        var drivers = _driverService.GetUnassignedDrivers();
        Console.Clear();
        Console.WriteLine("=== UNASSIGNED DRIVERS ===");
        foreach (var d in drivers)
        {
            Console.WriteLine($"{d.Id}) {d.FirstName} {d.LastName}");
        }

        Console.ReadKey();
    }

    private void AssignDriver()
    {
        Console.Clear();
        Console.WriteLine("=== ASSIGN DRIVER ===");

        int driverId = InputHelper.ReadInt("Enter Driver ID: ");

        int carId = InputHelper.ReadInt("Enter Car ID: ");

        int shiftChoice = InputHelper.ReadMenuChoice("Select Shift: 1) Morning 2) Afternoon 3) Evening", 1, 3);

        Shift shift = shiftChoice switch
        {
            1  => Shift.Morning,
            2 => Shift.Afternoon,
            3 => Shift.Evening,
        };

        _driverService.AssignDriver(driverId, carId, shift);

        Console.ReadKey();
    }

    private void UnassignDriver()
    {
        Console.Clear();
        Console.WriteLine("=== UNASSIGN DRIVER ===");

        int assignmentId = InputHelper.ReadInt("Enter Assignment ID: "); 

        _driverService.UnassignDriver(assignmentId);

        Console.ReadKey();
    }

    private void ViewAssignments()
    {
        var assignments = _driverService.GetAssignments();
        Console.Clear();
        Console.WriteLine("=== ASSIGNMENTS ===");

        foreach (var a in assignments.Where(x=> x.IsActive))
        {
            Console.WriteLine($"{a.Id}) Driver: {a.Driver.FirstName} {a.Driver.LastName} → Car: {a.Car.Model} → Shift: {a.Shift}");
        }

        Console.ReadKey();
    }
}
