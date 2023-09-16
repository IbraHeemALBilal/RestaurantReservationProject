using RestaurantReservation.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly RestaurantReservationDbContext _dbContext;

        private static EmployeeRepository _instance;

        private EmployeeRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public static EmployeeRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    var restaurantReservationDbContext = RestaurantReservationDbContext.Instance;
                    _instance = new EmployeeRepository(restaurantReservationDbContext);
                }
                return _instance;
            }
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task CreateAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task< List<Employee>> ListManagersAsync()
        {
            return await _dbContext.Employees.Where(e => e.Position == "Manager").ToListAsync();
        }

    }
}
