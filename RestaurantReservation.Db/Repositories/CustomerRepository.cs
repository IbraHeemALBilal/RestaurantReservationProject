using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private static CustomerRepository _instance;

        private CustomerRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public static CustomerRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    var restaurantReservationDbContext = RestaurantReservationDbContext.Instance;
                    _instance = new CustomerRepository(restaurantReservationDbContext);
                }
                return _instance;
            }
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }
        public async Task<Customer> GetByIdAsync(int customerId)
        {
            return await _dbContext.Customers.FindAsync(customerId);
        }
        public async Task CreateAsync(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int customerId)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
