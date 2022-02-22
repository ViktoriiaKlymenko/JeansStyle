using JeansStyle.DAL.Data.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JeansStyle.DAL.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public List<T> FindAllWhere(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

    }
}
