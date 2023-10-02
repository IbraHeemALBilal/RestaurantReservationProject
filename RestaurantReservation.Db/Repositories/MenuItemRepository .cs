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

        public async Task<List<MenuItem>> GetAllAsync()
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
        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            var context = RestaurantReservationDbContext.Instance;
            var orderedMenuItems = await (from r in context.Reservations
                                          join o in context.Orders on r.ReservationId equals o.ReservationId
                                          join oi in context.OrderItems on o.OrderId equals oi.OrderId
                                          join mi in context.MenuItems on oi.MenuitemId equals mi.MenuItemId
                                          where r.ReservationId == reservationId
                                          select mi)
                                          .ToListAsync();

            return orderedMenuItems;
        }
    }
}
