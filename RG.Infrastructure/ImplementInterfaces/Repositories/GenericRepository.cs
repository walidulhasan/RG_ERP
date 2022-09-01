using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RG.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        // Instance of the DbContext. Must be passed or injected.        
        private DbContext Context { get; set; }
        public GenericRepository(DbContext context)
        {
            Context = context;
        }
        protected DbSet<TEntity> DbSet
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = Context.Set<TEntity>();
                return _dbSet;
            }
        }
        private DbSet<TEntity> _dbSet;

        public virtual async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await this.DbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default)
        {
            return await this.DbSet.Where(match).ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await this.DbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default)
        {
            return await this.DbSet.FirstOrDefaultAsync(match, cancellationToken);
        }



        public virtual async Task<object> InsertAsync(TEntity entity, bool saveChanges = true)
        {
            var rtn = await this.DbSet.AddAsync(entity);
            if (saveChanges)
            {
                ////Debugging use.
                //try
                //{
                await Context.SaveChangesAsync();
                //}
                //catch (Exception ex)
                //{
                //    var te = ex;
                //}
            }
            return rtn;
        }
        public virtual async Task InsertAsync(IList<TEntity> entity, bool saveChanges = false)
        {
            await this.DbSet.AddRangeAsync(entity);
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public virtual async Task DeleteAsync(object id, bool saveChanges = true)
        {
            var dataObject = this.DbSet.Find(id);
            this.DbSet.Remove(dataObject);
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public virtual async Task DeleteAsync(TEntity entity, bool saveChanges = true)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }


        public virtual async Task UpdateAsync(TEntity entity, bool saveChanges = true)
        {
            var entry = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, object key, bool saveChanges = true)
        {
            if (entity == null)
                return null;
            var exist = await this.DbSet.FindAsync(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                if (saveChanges)
                {
                    await Context.SaveChangesAsync();
                }
            }
            return exist;
        }

        public virtual async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.GetAll(null, null, null, null, null);
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.GetAll(predicate, null, null, null, null);
        }

        public IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            return this.GetAll(null, include, null, null, null);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            return this.GetAll(predicate, include, null, null, null);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null)
        {
            IQueryable<TEntity> query = GetQueryable(predicate, include);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }


        public IQueryable<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = GetQueryable(predicate, include);

            return query;
        }
        public async Task<TEntity?> GetLastRow(Expression<Func<TEntity, bool>> match                                
                                 , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByDesc = null
                                 , CancellationToken cancellationToken = default)
        {
            var lastItemQuery = this.DbSet.Where(match);
            if (orderByDesc != null)
            {
                lastItemQuery = orderByDesc(lastItemQuery);
            }
            var a = lastItemQuery.ToQueryString();

            return await lastItemQuery.FirstOrDefaultAsync(cancellationToken);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = this.DbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            return query;
        }


    }
}
