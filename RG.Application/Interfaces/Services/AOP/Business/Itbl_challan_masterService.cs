using RG.Application.Contracts.AOP.Business.tbl_challan_master.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AOP.Business
{
    public interface Itbl_challan_masterService
    {
        Task<ChallanCustomerInfoRM> GetChallanCustomerInfo(long issuanceDetailID, CancellationToken cancellationToken);
    }
}
