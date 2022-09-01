using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries.RequestResponseModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AOP.Business
{
    public interface ITbl_Issuance_MasterService
    {
        Task<List<SelectListItem>> GetDDLIssuance_Master(int supplierID, int gatePassDetailID, string predict);
        Task<List<SelectListItem>> GetDDLIssuance_DetailByMaster(long masterID, int gatePassDetailID, CancellationToken cancellationToken);
        Task<IssuanceDetailInfoSPRM> GetIssuanceDetailInfoByID(long issue_ID, long issue_DetailsID);
    }
}
