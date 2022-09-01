using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AOP.Business;
using RG.Application.Interfaces.Services.AOP.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AOP.Business
{
    public class Tbl_Issuance_MasterService : ITbl_Issuance_MasterService
    {
        private readonly ITbl_Issuance_MasterRepository tbl_Issuance_MasterRepository;
        public Tbl_Issuance_MasterService(ITbl_Issuance_MasterRepository _tbl_Issuance_MasterRepository)
        {
            tbl_Issuance_MasterRepository = _tbl_Issuance_MasterRepository;
        }

        public async Task<List<SelectListItem>> GetDDLIssuance_DetailByMaster(long masterID, int gatePassDetailID, CancellationToken cancellationToken)
        {
            return await tbl_Issuance_MasterRepository.GetDDLIssuance_DetailByMaster(masterID, gatePassDetailID, cancellationToken);
        }

        public async Task<List<SelectListItem>> GetDDLIssuance_Master(int supplierID, int gatePassDetailID, string predict)
        {
            return await tbl_Issuance_MasterRepository.GetDDLIssuance_Master(supplierID, gatePassDetailID, predict);
        }

        public async Task<IssuanceDetailInfoSPRM> GetIssuanceDetailInfoByID(long issue_ID, long issue_DetailsID)
        {
            return await tbl_Issuance_MasterRepository.GetIssuanceDetailInfoByID(issue_ID, issue_DetailsID);
        }
    }
}
