using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : IRepository<MenuItem>
    {
        private readonly RestaurantReservationDbContext _dbContext;

        private static MenuItemRepository _instance;

        private MenuItemRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public static MenuItemRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    var restaurantReservationDbContext = RestaurantReservationDbContext.Instance;
                    _instance = new MenuItemRepository(restaurantReservationDbContext);
                }
                return _instance;
            }
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _dbContext.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> GetByIdAsync(int id)
        {
            return await _dbContext.MenuItems.FindAsync(id);
        }

        public async Task CreateAsync(MenuItem menuItem)
        {
            _dbContext.MenuItems.Add(menuItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MenuItem menuItem)
        {
            _dbContext.MenuItems.Update(menuItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menuItem = await _dbContext.MenuItems.FindAsync(id);
            if (menuItem != null)
            {
                _dbContext.MenuItems.Remove(menuItem);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
