using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<bool> AddAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);
    }
}
