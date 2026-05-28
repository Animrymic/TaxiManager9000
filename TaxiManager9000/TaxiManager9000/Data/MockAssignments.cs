using TaxiManager9000.Models;
using TaxiManager9000.Enums;

namespace TaxiManager9000.Data;

public static class MockAssignments
{
    public static void Seed()
    {
        var driver = DataStore.Drivers[0];
        var car = DataStore.Cars[0];

        DataStore.DriverAssignments.Add(new DriverAssignment(
            1,
            driver,
            car,
            Shift.Morning
        )); 
    }
}
