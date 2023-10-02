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
        static async Task  Main(string[] args)
        {
            await ExecStoredProcedure();
        }
        //Create / update / delete
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

        //methods
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
        private static async Task CalcolateTheAvarageAmountOfEmployeOrders()
        {
            var orderRepository = OrderRepository.Instance;
            var employeeId = 1;
            var averageTotalAmount = await orderRepository.CalculateAverageOrderAmountAsync(employeeId);
            Console.WriteLine($"Average Total Amount for Employee {employeeId}: {averageTotalAmount}");
        }

        //views
        private static async Task GetAllReservationsWithCutemersAndRestorants()
        {
            var reservationRepositoy = ReservationRepository.Instance;
            var ReservationsWithDetails = await reservationRepositoy.GetReservationsWithDetailsAsync();
            foreach (var r in ReservationsWithDetails)
            {
                Console.WriteLine($"Reservation ID: {r.ReservationId}");
                Console.WriteLine($"Customer Name: {r.CustomerFirstName}");
                Console.WriteLine($"Restaurant Name: {r.RestaurantName}");
                Console.WriteLine($"Reservation Date: {r.ReservationDate}");
                Console.WriteLine();
            }
        }
        private static async Task GetEmployeesWithRestorantsDetails()
        {
            var employeeRepository = EmployeeRepository.Instance;

            var employeesWithDetails = await employeeRepository.GetEmployeesWithRestaurantDetailsAsync();

            foreach (var employee in employeesWithDetails)
            {
                Console.WriteLine($"Employee ID: {employee.EmployeeId}");
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Position: {employee.Position}");
                Console.WriteLine($"Restaurant Name: {employee.RestaurantName}");
                Console.WriteLine($"Restaurant Address: {employee.RestaurantAddress}");
                Console.WriteLine();
            }
        }

        //function
        private static async Task UseDataBaseFunction()
        {
            var context = RestaurantReservationDbContext.Instance;
            var restorants =await context.Restaurants.Where(r => RestaurantReservationDbContext.CalculateTotalRevenue(r.RestaurantId) > 108).ToListAsync();
            foreach (var res in restorants)
            {
                Console.WriteLine(res.Name);
            }
        }

        //StoredProcedure
        private static async Task ExecStoredProcedure()
        {
            var context = RestaurantReservationDbContext.Instance;
            var partySize = 5;
            var customers = await context.CustomersWithPartySize.FromSqlRaw("EXEC GetCustomersWithPartySizeGreaterThan {0}", partySize).ToListAsync();
            foreach (var c in customers)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}