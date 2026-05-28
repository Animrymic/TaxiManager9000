using TaxiManager9000.Enums;
namespace TaxiManager9000.Models;

public class DriverAssignment
{
    public int Id { get; set; }
    public Driver Driver { get; set; }
    public Car Car { get; set; }
    public Shift Shift { get; set; }
    public DateTime AssignedAt { get; set; }
    public bool IsActive { get; set; }

    public DriverAssignment()
    { 
    }

    public DriverAssignment(int id, Driver driver, Car car, Shift shift)
    {
        Id = id;
        Driver = driver;
        Car = car;
        Shift = shift;
        AssignedAt = DateTime.Now;
        IsActive = true;
    }
}
