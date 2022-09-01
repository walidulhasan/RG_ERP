using MediatR;
using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Detailss.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AOP.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AOP.Business.Tbl_Issuance_Detailss.Queries
{
    public class GetTbl_Issuance_DetailsByIDQurey : IRequest<Tbl_Issuance_DetailsRM>
    {
        public long ID { get; set; }
    }
    public class GetTbl_Issuance_DetailsByIDQureyHandler : IRequestHandler<GetTbl_Issuance_DetailsByIDQurey, Tbl_Issuance_DetailsRM>
    {
        private readonly ITbl_Issuance_DetailsService tbl_Issuance_DetailsService;
        public GetTbl_Issuance_DetailsByIDQureyHandler(ITbl_Issuance_DetailsService _tbl_Issuance_DetailsService)
        {
            tbl_Issuance_DetailsService = _tbl_Issuance_DetailsService;
        }
        public async Task<Tbl_Issuance_DetailsRM> Handle(GetTbl_Issuance_DetailsByIDQurey request, CancellationToken cancellationToken)
        {
            return await tbl_Issuance_DetailsService.GetTbl_Issuance_DetailsByID(request.ID, cancellationToken);
        }
    }
}
