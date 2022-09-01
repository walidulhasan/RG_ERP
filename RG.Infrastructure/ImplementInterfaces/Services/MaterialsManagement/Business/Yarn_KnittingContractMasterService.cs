using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
   public class Yarn_KnittingContractMasterService : IYarn_KnittingContractMasterService
    {
        private readonly IYarn_KnittingContractMasterRepository _yarn_KnittingContractMasterRepository;

        public Yarn_KnittingContractMasterService(IYarn_KnittingContractMasterRepository yarn_KnittingContractMasterRepository)
        {
            _yarn_KnittingContractMasterRepository = yarn_KnittingContractMasterRepository;
        }

        public async Task<Yarn_KnittingContractMaster> GetYarn_KnittingContractMaster(long YarnKNContractID, CancellationToken cancellationToken=default)
        {
            return await _yarn_KnittingContractMasterRepository.GetYarn_KnittingContractMaster(YarnKNContractID, cancellationToken);
        }
    }
}
