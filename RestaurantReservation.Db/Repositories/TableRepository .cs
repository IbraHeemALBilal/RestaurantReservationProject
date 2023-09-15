using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository : IRepository<Table>
    {
        private readonly RestaurantReservationDbContext _dbContext;

        private static TableRepository _instance;

        private TableRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public static TableRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    var restaurantReservationDbContext = RestaurantReservationDbContext.Instance;
                    _instance = new TableRepository(restaurantReservationDbContext);
                }
                return _instance;
            }
        }

        public async Task<IEnumerable<Table>> GetAllAsync()
        {
            return await _dbContext.Tables.ToListAsync();
        }

        public async Task<Table> GetByIdAsync(int tableId)
        {
            return await _dbContext.Tables.FindAsync(tableId);
        }

        public async Task CreateAsync(Table table)
        {
            _dbContext.Tables.Add(table);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Table table)
        {
            _dbContext.Tables.Update(table);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int tableId)
        {
            var table = await _dbContext.Tables.FindAsync(tableId);
            if (table != null)
            {
                _dbContext.Tables.Remove(table);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
