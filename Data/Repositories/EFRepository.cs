using Architecture.Domain.Entities;
using Core.Interfaces.Repositories;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly AppDbContext AppDbContext;
        protected DbSet<T> _entities => AppDbContext.Set<T>();
        public EFRepository(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public virtual async Task<T> GetById(int id)
        {
            return await AppDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<List<T>> ListAll()
        {
            return await AppDbContext.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T> Add(T entity)
        {
            AppDbContext.Set<T>().Add(entity);
            await AppDbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(T entity)
        {
            AppDbContext.Update(entity);
            await AppDbContext.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            AppDbContext.Set<T>().Remove(entity);
            await AppDbContext.SaveChangesAsync();
        }
        public Task<bool> Any(Func<T, bool> predicate)
        {
            return Task.FromResult(AppDbContext.Set<T>().AsNoTracking().Any(predicate));
        }
        public Task<List<T>> ListWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes)
        {

            var query = AppDbContext.Set<T>().AsQueryable();
            for (int i = 0; i < includes.Length; i++)
            {
                query = query.Include(includes[i]).AsNoTracking();
            }
            return Task.FromResult(query.Where(predicate).ToList());
        }
        public Task<T> GetSingleBySpec(Func<T, bool> predicate)
        {
            return Task.FromResult(AppDbContext.Set<T>().AsNoTracking().FirstOrDefault(predicate));
        }
        public Task<List<T>> List(Func<T, bool> predicate)
        {
            return Task.FromResult(AppDbContext.Set<T>().Where(predicate).ToList());
        }
    }
}
