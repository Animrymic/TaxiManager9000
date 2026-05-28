namespace TaxiManager9000.Models;

public class Car
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string LicensePlate { get; set; } = string.Empty;
    public DateTime LicenseExpiryDate { get; set; }
    public List<Driver> AssignedDrivers { get; set; } = new List<Driver>();

    public Car()
    { 
    }

    public Car(int id, string model, string licensePlate, DateTime licenseExpiryDate)
    {
        Id = id;
        Model = model;
        LicensePlate = licensePlate;
        LicenseExpiryDate = licenseExpiryDate;
        AssignedDrivers = new List<Driver>();
    }
}


