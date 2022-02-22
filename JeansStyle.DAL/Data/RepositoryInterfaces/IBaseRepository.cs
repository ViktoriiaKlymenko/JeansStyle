using System;
using System.Collections.Generic;

namespace JeansStyle.DAL.Data.RepositoryInterfaces
{
    public interface IBaseRepository<T>
    {
        List<T> FindAllWhere(Func<T, bool> predicate);
    }
}