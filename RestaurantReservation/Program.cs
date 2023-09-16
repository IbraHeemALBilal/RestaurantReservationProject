using Microsoft.EntityFrameworkCore;
using RestaurantReservation;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using System.Linq;

namespace RestaurantReservation
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await CalcolateTheAvarageAmountOfEmployeOrders();
        }

        private static async Task GetMenuItemsForReservation()
        {
            var menuItemRepository = MenuItemRepository.Instance;
            var reservationId = 1;
            var list = await menuItemRepository.ListOrderedMenuItemsAsync(reservationId);
            foreach (var item in list)
            {
                Console.WriteLine(item.Description);
            }
        }
        private static async Task CreateCustemer()
        {
            var customerRepository = CustomerRepository.Instance;

            var newCustomer = new Customer
            {
                FirstName = "Ib",
                LastName = "Al",
                Email = "IB.dooe@example.com",
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
        private static async Task ListTheMangers()
        {
            var employeeRepository = EmployeeRepository.Instance;
            var managers = await employeeRepository.ListManagersAsync();
            foreach (var manager in managers)
            {
                Console.WriteLine(manager.FirstName);
            }
        }
        private static async Task GetCustomerReservations()
        {
            var reservationRepository = ReservationRepository.Instance;
            var customerId = 5;
            var customerReservations = await reservationRepository.GetReservationsByCustomerAsync(customerId);
            foreach (var customerReservation in customerReservations)
            {
                Console.WriteLine(customerReservation.ReservationId);
            }
        }
        private static async Task CalcolateTheAvarageAmountOfEmployeOrders()
        {
            var orderRepository = OrderRepository.Instance;
            var employeeId = 1;
            var averageTotalAmount = await orderRepository.CalculateAverageOrderAmountAsync(employeeId);
            Console.WriteLine($"Average Total Amount for Employee {employeeId}: {averageTotalAmount}");
        }



    }
}