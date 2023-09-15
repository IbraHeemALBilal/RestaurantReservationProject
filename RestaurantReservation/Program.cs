using RestaurantReservation;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new RestaurantReservationDbContext();
            var custemers = context.Customers.ToList();
            Console.WriteLine (custemers.ToString());
        }
    }
}