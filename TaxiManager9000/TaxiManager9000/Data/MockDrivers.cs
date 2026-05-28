using TaxiManager9000.Models;
using TaxiManager9000.Enums;

namespace TaxiManager9000.Data;

public static class MockDrivers
{
    public static void Seed()
    {
        DataStore.Drivers.AddRange(new List<Driver>
        {
            new Driver(1, "John", "Doe", Shift.Morning, DateTime.Now.AddYears(1)),
            new Driver(2, "Anna", "Smith", Shift.Afternoon, DateTime.Now.AddMonths(6)),
            new Driver(3, "Peter", "Johnson", Shift.Evening, DateTime.Now.AddMonths(2))
        });
    }
}

