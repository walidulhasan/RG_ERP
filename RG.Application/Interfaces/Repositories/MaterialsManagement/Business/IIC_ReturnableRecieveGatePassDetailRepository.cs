using RG.Application.Common.Models;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface IIC_ReturnableRecieveGatePassDetailRepository : IGenericRepository<IC_ReturnableRecieveGatePassDetail>
    {
        Task<RResult> SaveReturnableRecieveGatePassDetail(List<IC_ReturnableRecieveGatePassDetail> entity, CancellationToken cancellationToken);
    }
}
