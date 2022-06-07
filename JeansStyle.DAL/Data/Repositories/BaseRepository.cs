using Ardalis.Specification;
using JeansStyle.DAL.Data.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JeansStyle.DAL.Data.Repositories
{
    public sealed class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DataContext _context;
        private readonly ISpecificationEvaluator<T> _specificationEvaluator;
        public BaseRepository(DataContext context)
        : this(context, new SpecificationEvaluator<T>())
        {
        }
        public BaseRepository(DataContext context,
            ISpecificationEvaluator<T> specificationEvaluator)
        {
            _context = context;
            _specificationEvaluator = specificationEvaluator;
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public List<T> FindAllWhere(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public async Task<T> GetBySpecAsync(ISpecification<T> specification) =>
         await ApplySpecification(specification).FirstOrDefaultAsync();



        public async Task<List<T>> ListAsync(ISpecification<T> specification) =>
                    await ApplySpecification(specification).ToListAsync();

        private IQueryable<T> ApplySpecification(ISpecification<T> specification) =>
        _specificationEvaluator.GetQuery(GetDbSet().AsQueryable(), specification);

        private DbSet<T> GetDbSet() =>
           _context.Set<T>();
        public void Clear() => _context.ChangeTracker.Clear();

        public T FindWhere(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public void Add(T item)
        {
            _context.Attach(item);
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }


      
    }
}
