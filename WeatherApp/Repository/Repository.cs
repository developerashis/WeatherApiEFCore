using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly WeatherDbContext _weatherDbContext;

        public Repository(WeatherDbContext weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _weatherDbContext.Set<TEntity>();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            await _weatherDbContext.AddAsync(entity);
            var result = await _weatherDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            _weatherDbContext.Update(entity);
            var result = await _weatherDbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
