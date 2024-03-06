using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppTv.Models.Entities;
using SQLite;
using SQLitePCL;
namespace AppTv.Persistence
{
    class DbContext
    {
        readonly SQLiteAsyncConnection _database;

        public DbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public Task<List<Movies>> ObtenerPeliculasAsync()
        {
            return _database.Table<Movies>().ToListAsync();
        }

        public Task<int> GuardarPeliculaAsync(Movies Movie)
        {
            if (Movie.Id != 0)
            {
                return _database.UpdateAsync(Movie);
            }
            else
            {
                return _database.InsertAsync(Movie);
            }
        }
    }
}
