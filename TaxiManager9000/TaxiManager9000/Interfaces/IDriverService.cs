using TaxiManager9000.Enums;
using TaxiManager9000.Models;

namespace TaxiManager9000.Interfaces;

public interface IDriverService
{
    void AssignDriver(int driverId, int carId, Shift shift);
    void UnassignDriver(int assignmentId);

    List<Driver> GetAllDrivers();
    List<Driver> GetUnassignedDrivers(); 
    List<DriverAssignment> GetAssignments();
}
