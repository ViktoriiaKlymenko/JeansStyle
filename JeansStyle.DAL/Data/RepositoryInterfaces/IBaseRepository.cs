using JeansStyle.DAL.Domain.Models;
using System;
using System.Collections.Generic;

namespace JeansStyle.DAL.Data.RepositoryInterfaces
{
    public interface IBaseRepository<T>: IDisposable where T: class
    {
        List<T> FindAllWhere(Func<T, bool> predicate);
        List<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}