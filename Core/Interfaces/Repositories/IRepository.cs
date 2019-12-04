using Architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<T> GetById(int id);
        Task<List<T>> ListAll();
        Task<T> GetSingleBySpec(Func<T, bool> predicate);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Any(Func<T, bool> predicate);
        Task<List<T>> List(Func<T, bool> predicate);
        Task<List<T>> ListWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes);
    }
}
