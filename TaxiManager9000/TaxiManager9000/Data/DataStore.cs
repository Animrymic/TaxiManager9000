using TaxiManager9000.Models;
namespace TaxiManager9000.Data
{
    public static class DataStore
    {
        public static List<User> Users = new List<User>(); 
        public static List<Driver> Drivers = new List<Driver>();
        public static List<Car> Cars = new List<Car>(); 
        public static List<DriverAssignment> DriverAssignments = new List<DriverAssignment>();
    }
}
