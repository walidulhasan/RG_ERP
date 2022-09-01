using RG.Application.Contracts.MaterialsManagement.AttributesDTO;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public interface IMM_MRPItemService
    {
        Task<MM_MRPItem> GetMRPItemById(Expression<Func<MM_MRPItem, bool>> match, CancellationToken cancellationToken=default);
        Task<IList<MM_MRPItem>> GetManyMRPItem(Expression<Func<MM_MRPItem, bool>> match, CancellationToken cancellationToken=default);
    
        Task<Attributes> GetMRPItemAttributeSet(int MRPItemCode, CancellationToken cancellationToken=default);
    }
}
