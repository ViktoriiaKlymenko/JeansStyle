using Ardalis.Specification;
using JeansStyle.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeansStyle.DAL.Data.RepositoryInterfaces
{
    public interface IBaseRepository<T>: IDisposable where T: class
    {
        List<T> FindAllWhere(Func<T, bool> predicate);
        T FindWhere(Func<T, bool> predicate);
        int Count();
        List<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void Clear();
        Task<List<T>> ListAsync(ISpecification<T> specification);
        Task<T> GetBySpecAsync(ISpecification<T> specification);
    }
}