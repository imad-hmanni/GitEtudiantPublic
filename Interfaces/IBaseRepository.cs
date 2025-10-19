using GestionEtudiant.Repository;
using System.Linq.Expressions;

namespace GestionEtudiant.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T? GetById(int id);

        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        public bool Any(Expression<Func<T, bool>> predicate);

        
    }

}