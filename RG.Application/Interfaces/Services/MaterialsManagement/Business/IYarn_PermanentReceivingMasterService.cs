using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_PermanentReceivingMasters.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
  public  interface IYarn_PermanentReceivingMasterService
    {
        Task<List<YarnReceivingByPoRM>> YarnReceivingByPOForRackAllocation(long SupplierID = 0, long POID = 0, long YarnPermRecID = 0, int TopData = 500,string LotNo="", CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> DDLYarnReceivedBalanceLot(long SupplierID = 0, long POID = 0, int TopData = 500, string Predict = null, CancellationToken cancellationToken = default);
    }
}
