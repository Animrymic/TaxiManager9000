using TaxiManager9000.Models;

namespace TaxiManager9000.Data;

public static class MockCars
{
    public static void Seed()
    {
        DataStore.Cars.AddRange(new List<Car>
        {
            new Car (1, "Toyota Prius", "SK-2995-BZ", DateTime.Now.AddYears(1)),
            new Car (2, "BMW X5", "SK-3746-VD", DateTime.Now.AddMonths(2)),
            new Car (3, "Skoda Octavia", "SK-2342-DF", DateTime.Now.AddMonths(8))
        });
    }
}
