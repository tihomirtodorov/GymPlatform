using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : AuditableBaseEntity
    {
        protected readonly ApplicationDbContext dbContext;

        protected GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected abstract IQueryable<TEntity> Query { get; }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Query.ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, Guid id)
        {
            if (entity == null)
                return null;

            entity.Id = id; // TODO 
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return;

            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
