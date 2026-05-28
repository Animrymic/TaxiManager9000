using System.Diagnostics;
using TaxiManager9000.Models;

namespace TaxiManager9000.Interfaces;

public interface ICarService
{
    List<Car> GetAllCars();
    List<Car> GetOperationalCars();
    string GetCarStatus(Car car);
    double CalculateUtilization(Car car);
}
