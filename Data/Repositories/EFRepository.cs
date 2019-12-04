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
        public readonly AppDbContext _appDbContext;
        public EFRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public virtual async Task<T> GetById(int id)
        {
            return await _appDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<List<T>> ListAll()
        {
            return await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T> Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(T entity)
        {
            _appDbContext.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }
        public Task<bool> Any(Func<T, bool> predicate)
        {
            return Task.FromResult(_appDbContext.Set<T>().AsNoTracking().Any(predicate));
        }
        public Task<List<T>> ListWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes)
        {

            var query = _appDbContext.Set<T>().AsQueryable();
            for (int i = 0; i < includes.Length; i++)
            {
                query = query.Include(includes[i]).AsNoTracking();
            }
            return Task.FromResult(query.Where(predicate).ToList());
        }
        public Task<T> GetSingleBySpec(Func<T, bool> predicate)
        {
            return Task.FromResult(_appDbContext.Set<T>().AsNoTracking().FirstOrDefault(predicate));
        }
        public Task<List<T>> List(Func<T, bool> predicate)
        {
            return Task.FromResult(_appDbContext.Set<T>().Where(predicate).ToList());
        }
    }
}
