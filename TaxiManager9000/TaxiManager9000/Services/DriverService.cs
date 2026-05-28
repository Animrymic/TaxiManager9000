using TaxiManager9000.Data;
using TaxiManager9000.Enums;
using TaxiManager9000.Interfaces;
using TaxiManager9000.Models;

namespace TaxiManager9000.Services;

public class DriverService : IDriverService
{
    public void AssignDriver(int driverId, int carId, Shift shift)
    {
        var driver = DataStore.Drivers.FirstOrDefault(d => d.Id == driverId);
        var car = DataStore.Cars.FirstOrDefault(c => c.Id == carId);

        if(driver == null || car == null)
        {
            Console.WriteLine("Driver or Car not found.");
            return;
        }

        if(driver.LicenseExpiryDate < DateTime.Now)
        {
            Console.WriteLine("Car license has expired.");
            return;
        }

        bool carBusy = DataStore.DriverAssignments.Any(a =>
        a.Car.Id == carId &&
        a.Shift == shift &&
        a.IsActive); 

        if(carBusy)
        {
            Console.WriteLine("Car is already assigned in this shift.");
            return;
        }

        bool driverBusy = DataStore.DriverAssignments.Any(a =>
        a.Driver.Id == driverId &&
        a.Shift == shift &&
        a.IsActive); 

        if (driverBusy)
        {
            Console.WriteLine("Driver already assigned in this shift.");
            return;
        }

        int newId = DataStore.DriverAssignments.Count + 1;
        var assignment = new DriverAssignment(newId, driver, car, shift);

        DataStore.DriverAssignments.Add(assignment);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Driver successfully assigned!");
        Console.ResetColor();
    }

    public void UnassignDriver(int assignmentId)
    {
        var assignment = DataStore.DriverAssignments
            .FirstOrDefault(a => a.Id == assignmentId);
        if(assignment == null)
        {
            Console.WriteLine("Assignment not found!");
            return;
        }

        assignment.IsActive = false;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Driver unassigned successfully!");
        Console.ResetColor(); 
    }


    public List<Driver> GetAllDrivers()
    {
        return DataStore.Drivers;
    }

    public List<Driver> GetUnassignedDrivers()
    {
        var assignedDriverIds = DataStore.DriverAssignments
            .Where(a => a.IsActive)
            .Select(a => a.Driver.Id)
            .ToList();

        return DataStore.Drivers
            .Where(d => !assignedDriverIds.Contains(d.Id))
            .ToList();
    }


    public List<DriverAssignment> GetAssignments()
    {
        return DataStore.DriverAssignments;
    }




}
