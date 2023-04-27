
namespace Models.Services
{
    public static class Validator
    {
        public static bool Validate(Vehicle vehicle)
        {
            if(vehicle.Id == 0 || vehicle.Type == string.Empty || vehicle.YearOfProduction == 0)
            {
                return false;
            }
            return true;
        }
    }
}
