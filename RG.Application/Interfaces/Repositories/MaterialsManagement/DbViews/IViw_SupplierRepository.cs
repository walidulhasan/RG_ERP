using RG.DBEntities.MaterialsManagement.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.DbViews
{
  public interface IViw_SupplierRepository
    {
        Task<List<Viw_Supplier>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<Viw_Supplier>> FindAllAsync(Expression<Func<Viw_Supplier, bool>> match, CancellationToken cancellationToken = default);
        Task<Viw_Supplier> GetByIdAsync(object id, CancellationToken cancellationToken = default);
        Task<Viw_Supplier> FindAsync(Expression<Func<Viw_Supplier, bool>> match, CancellationToken cancellationToken = default);
    }
}
