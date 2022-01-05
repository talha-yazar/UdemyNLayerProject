﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Data.Repositories
{
    
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await this._dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this._dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this._dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this._dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this._dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return this._dbSet.Where(predicate);
        }
    }
}
