using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface IYarn_KnittingContractMasterService
    {
        Task<Yarn_KnittingContractMaster> GetYarn_KnittingContractMaster(long YarnKNContractID, CancellationToken cancellationToken = default);
    }
}
