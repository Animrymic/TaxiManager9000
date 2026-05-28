using TaxiManager9000.Enums;

namespace TaxiManager9000.Models;

public class Driver 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Shift Shift { get; set; }
    public DateTime LicenseExpiryDate { get; set; }

    public Driver()
    {
    }

    public Driver(int id, string firstName, string lastName, Shift shift, DateTime licenseExpiryDate)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Shift = shift;
        LicenseExpiryDate = licenseExpiryDate;

    }


}