using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken=default);
        Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(object id, CancellationToken cancellationToken = default);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken = default);

        Task<object> InsertAsync(TEntity entity, bool saveChanges = true);
        Task InsertAsync(IList<TEntity> entity, bool saveChanges = false);
        Task DeleteAsync(object id, bool saveChanges = true);
        Task DeleteAsync(TEntity entity, bool saveChanges = true);
        Task UpdateAsync(TEntity entity, bool saveChanges = true);
        Task<TEntity> UpdateAsync(TEntity entity, object key, bool saveChanges = true);
        Task CommitAsync();


        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null);



        IQueryable<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity?> GetLastRow(Expression<Func<TEntity, bool>> match                             
                             , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByDesc = null
                             , CancellationToken cancellationToken = default);
        void Dispose();
    }
}
