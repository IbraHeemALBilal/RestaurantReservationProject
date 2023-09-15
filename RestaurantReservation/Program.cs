using RestaurantReservation;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation
{
    public class Program
    {
        static async Task Main(string[] args)
        {

        }

        private static async Task CreateCustemer()
        {
            var customerRepository = CustomerRepository.Instance;

            var newCustomer = new Customer
            {
                FirstName = "Ib",
                LastName = "Al",
                Email = "IB.doe@example.com",
                PhoneNumber = "123-456-7555"
            };

            await customerRepository.CreateAsync(newCustomer);

            Console.WriteLine("Customer created successfully!");
        }
        private static async Task UpdateCustemer()
        {
            var customerRepository = CustomerRepository.Instance;
            var customerIdToUpdate = 1;
            var customerToUpdate = await customerRepository.GetByIdAsync(customerIdToUpdate);

            if (customerToUpdate != null)
            {
                customerToUpdate.FirstName = "Ibraheeeem";
                customerToUpdate.LastName = "Albilal";
                customerToUpdate.Email = "Ib@gmail.com";
                customerToUpdate.PhoneNumber = "123-456-7890";

                await customerRepository.UpdateAsync(customerToUpdate);
            }
        }
        private static async Task DeleteCustomer()
        {
            var customerRepository = CustomerRepository.Instance;

            var customerIdToDelete = 6;

            await customerRepository.DeleteAsync(customerIdToDelete);

            Console.WriteLine("Customer deleted successfully!");
        }
    }
}