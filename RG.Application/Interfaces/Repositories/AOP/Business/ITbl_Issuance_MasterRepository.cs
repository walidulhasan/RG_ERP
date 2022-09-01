using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries.RequestResponseModel;
using RG.DBEntities.AOP.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AOP.Business
{
    public interface ITbl_Issuance_MasterRepository : IGenericRepository<Tbl_Issuance_Master>
    {
        Task<List<SelectListItem>> GetDDLIssuance_Master(int supplierID, int gatePassDetailID, string predict);
        Task<List<SelectListItem>> GetDDLIssuance_DetailByMaster(long masterID, int gatePassDetailID, CancellationToken cancellationToken);
        Task<IssuanceDetailInfoSPRM> GetIssuanceDetailInfoByID(long issue_ID, long issue_DetailsID);
        Task<IssuancePaymentInfoSPRM> GetIssuancePaymentInfo(long issueDetailId);
    }
}

