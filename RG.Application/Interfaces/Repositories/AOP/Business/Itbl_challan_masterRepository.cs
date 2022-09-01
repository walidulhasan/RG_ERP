using RG.Application.Contracts.AOP.Business.tbl_challan_master.Queries.RequestResponseModel;
using RG.DBEntities.AOP.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AOP.Business
{
    public interface Itbl_challan_masterRepository : IGenericRepository<tbl_challan_master>
    {
        Task<ChallanCustomerInfoRM> GetChallanCustomerInfo(long issuanceDetailID, CancellationToken cancellationToken);
    }
}
