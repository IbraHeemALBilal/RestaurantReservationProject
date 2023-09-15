﻿namespace RestaurantReservation.Db.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }

}
