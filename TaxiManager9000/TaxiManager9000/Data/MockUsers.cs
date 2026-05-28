using TaxiManager9000.Models;
using TaxiManager9000.Enums;

namespace TaxiManager9000.Data;

public static class MockUsers
{
    public static void Seed()
    {
        DataStore.Users.AddRange(new List<User>
        {
            new User (1, "admin", "admin123", Role.Administrator),
            new User (2, "manager", "manager123", Role.Manager),
            new User (3, "maint", "maint123", Role.Maintenance)
        });
    }
}
