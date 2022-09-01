using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_PermanentReceivingMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class Yarn_PermanentReceivingMasterService : IYarn_PermanentReceivingMasterService
    {
        private readonly IYarn_PermanentReceivingMasterRepository _yarn_PermanentReceivingMasterRepository;

        public Yarn_PermanentReceivingMasterService(IYarn_PermanentReceivingMasterRepository yarn_PermanentReceivingMasterRepository)
        {
            _yarn_PermanentReceivingMasterRepository = yarn_PermanentReceivingMasterRepository;
        }

        public async Task<List<SelectListItem>> DDLYarnReceivedBalanceLot(long SupplierID = 0, long POID = 0,int TopData=500, string Predict = null, CancellationToken cancellationToken = default)
        {
            return await _yarn_PermanentReceivingMasterRepository.DDLYarnReceivedBalanceLot(SupplierID, POID,TopData, Predict, cancellationToken);
        }

        public async Task<List<YarnReceivingByPoRM>> YarnReceivingByPOForRackAllocation(long SupplierID = 0, long POID = 0, long YarnPermRecID = 0, int TopData = 500,string LotNo="", CancellationToken cancellationToken = default)
        {
            return await _yarn_PermanentReceivingMasterRepository.YarnReceivingByPOForRackAllocation(SupplierID, POID, YarnPermRecID, TopData,LotNo, cancellationToken);
        }
    }
}
