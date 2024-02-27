using System;
using System.Collections.Generic;
using System.Text;

namespace AppTv.Persistence
{
    interface IRepository<T>
    {
        IEnumerable<T> GetMovies();
        void Add(T entity);

    }
}
