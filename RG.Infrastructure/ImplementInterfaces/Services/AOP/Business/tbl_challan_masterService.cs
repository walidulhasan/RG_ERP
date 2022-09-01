using RG.Application.Contracts.AOP.Business.tbl_challan_master.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AOP.Business;
using RG.Application.Interfaces.Services.AOP.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AOP.Business
{
    public class tbl_challan_masterService : Itbl_challan_masterService
    {
        private readonly Itbl_challan_masterRepository _tbl_Challan_MasterRepository;

        public tbl_challan_masterService(Itbl_challan_masterRepository tbl_Challan_MasterRepository)
        {
            _tbl_Challan_MasterRepository = tbl_Challan_MasterRepository;
        }
        public async Task<ChallanCustomerInfoRM> GetChallanCustomerInfo(long issuanceDetailID, CancellationToken cancellationToken)
        {
            return await _tbl_Challan_MasterRepository.GetChallanCustomerInfo(issuanceDetailID, cancellationToken);
        }
    }
}
