using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Views;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly RestaurantReservationDbContext _dbContext;

        private static ReservationRepository _instance;

        private ReservationRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public static ReservationRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    var restaurantReservationDbContext = RestaurantReservationDbContext.Instance;
                    _instance = new ReservationRepository(restaurantReservationDbContext);
                }
                return _instance;
            }
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _dbContext.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int reservationId)
        {
            return await _dbContext.Reservations.FindAsync(reservationId);
        }
        public async Task CreateAsync(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Reservation reservation)
        {
            _dbContext.Reservations.Update(reservation);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int reservationId)
        {
            var reservation = await _dbContext.Reservations.FindAsync(reservationId);
            if (reservation != null)
            {
                _dbContext.Reservations.Remove(reservation);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Reservation>> GetReservationsByCustomerAsync(int CustomerId)
        {
            return await _dbContext.Reservations.Where(r=>r.CustomerId== CustomerId).ToListAsync();
        }

        public async Task<List<ReservationView>> GetReservationsWithDetailsAsync()
        {
            return await _dbContext.ReservationViews.ToListAsync();
        }
    }
}
