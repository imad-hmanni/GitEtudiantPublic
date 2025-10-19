using GestionEtudiant.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GestionEtudiant
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();
        public T? GetById(int id) => _dbSet.Find(id);
        public void Add(T entity) { _dbSet.Add(entity); _context.SaveChanges(); }
        public void Update(T entity) { _dbSet.Update(entity); _context.SaveChanges(); }
        public void Delete(T entity) { _dbSet.Remove(entity); _context.SaveChanges(); }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

    }
}
