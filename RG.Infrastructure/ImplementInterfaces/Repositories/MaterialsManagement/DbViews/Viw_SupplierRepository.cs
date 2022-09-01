using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.MaterialsManagement.DbViews;
using RG.DBEntities.MaterialsManagement.DBViews;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.DbViews
{
   public class Viw_SupplierRepository: IViw_SupplierRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;

        public Viw_SupplierRepository(MaterialsManagementDBContext dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<Viw_Supplier>> FindAllAsync(Expression<Func<Viw_Supplier, bool>> match, CancellationToken cancellationToken = default)
        {
            return await _dbCon.Viw_Supplier.Where(match).ToListAsync(cancellationToken); 
        }

        public async Task<Viw_Supplier> FindAsync(Expression<Func<Viw_Supplier, bool>> match, CancellationToken cancellationToken = default)
        {
            return await _dbCon.Viw_Supplier.FirstOrDefaultAsync(match,cancellationToken);
        }

        public async Task<List<Viw_Supplier>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbCon.Viw_Supplier.ToListAsync(cancellationToken);
        }

        public async Task<Viw_Supplier> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await _dbCon.Viw_Supplier.FindAsync(new object[] {id}, cancellationToken);
        }
    }
}
