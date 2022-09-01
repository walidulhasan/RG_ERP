using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Detailss.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AOP.Business
{
    public interface ITbl_Issuance_DetailsService
    {
        Task<Tbl_Issuance_DetailsRM> GetTbl_Issuance_DetailsByID(long id, CancellationToken cancellationToken);
    }
}
