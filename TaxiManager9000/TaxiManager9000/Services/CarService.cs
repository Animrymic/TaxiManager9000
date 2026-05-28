using TaxiManager9000.Data;
using TaxiManager9000.Interfaces;
using TaxiManager9000.Models;

namespace TaxiManager9000.Services;

public class CarService : ICarService
{
    public List<Car> GetAllCars()
    {
        return DataStore.Cars;
    }
    public List<Car> GetOperationalCars()
    {
        return DataStore.Cars
            .Where(c => c.LicenseExpiryDate > DateTime.Now)
            .ToList();
    }

    public string GetCarStatus(Car car)
    {
        var daysLeft = (car.LicenseExpiryDate - DateTime.Now).TotalDays;

        if (daysLeft < 0)
            return "EXPIRED";

        if (daysLeft <= 90)
            return "EXPIRING SOON";

        return "VALID";
    }

    public double CalculateUtilization(Car car)
    {
        var totalShifts = DataStore.DriverAssignments
            .Where(a => a.Car.Id == car.Id && a.IsActive)
            .Select(a => a.Shift)
            .Distinct()
            .Count();

        return (totalShifts / 3.0) * 100;
    }
}
