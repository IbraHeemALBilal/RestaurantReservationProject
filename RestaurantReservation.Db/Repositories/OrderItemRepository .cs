﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository : IRepository<OrderItem>
    {
        private readonly RestaurantReservationDbContext _dbContext;

        private static OrderItemRepository _instance;

        private OrderItemRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public static OrderItemRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    var restaurantReservationDbContext = RestaurantReservationDbContext.Instance;
                    _instance = new OrderItemRepository(restaurantReservationDbContext);
                }
                return _instance;
            }
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            return await _dbContext.OrderItems.FindAsync(id);
        }

        public async Task CreateAsync(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            _dbContext.OrderItems.Update(orderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderItem = await _dbContext.OrderItems.FindAsync(id);
            if (orderItem != null)
            {
                _dbContext.OrderItems.Remove(orderItem);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
