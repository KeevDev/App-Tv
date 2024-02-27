using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTv.Persistence
{
    public interface IRepository<Movies> where Movies : class
    {
        Task<List<Movies>> GetAllAsync();
        Task<Movies> GetByIdAsync(int id);
        Task AddAsync(Movies movie);
        Task UpdateAsync(Movies movie);
        Task DeleteAsync(Movies movie);
    }
}

