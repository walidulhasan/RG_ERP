using MediatR;
using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AOP.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries
{
    public class GetIssuanceDetailInfoByIDQuery : IRequest<IssuanceDetailInfoSPRM>
    {
        public long issue_ID { get; set; }
        public long issue_DetailsID { get; set; }
    }
    public class GetIssuanceDetailInfoByIDQueryHandler : IRequestHandler<GetIssuanceDetailInfoByIDQuery, IssuanceDetailInfoSPRM>
    {
        private readonly ITbl_Issuance_MasterService tbl_Issuance_MasterService;

        public GetIssuanceDetailInfoByIDQueryHandler(ITbl_Issuance_MasterService _tbl_Issuance_MasterService)
        {
            tbl_Issuance_MasterService = _tbl_Issuance_MasterService;
        }
        public async Task<IssuanceDetailInfoSPRM> Handle(GetIssuanceDetailInfoByIDQuery request, CancellationToken cancellationToken)
        {
            return await tbl_Issuance_MasterService.GetIssuanceDetailInfoByID(request.issue_ID, request.issue_DetailsID);
        }
    }
}
