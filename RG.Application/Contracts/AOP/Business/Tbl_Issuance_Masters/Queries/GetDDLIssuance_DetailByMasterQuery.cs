using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AOP.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries
{
    public class GetDDLIssuance_DetailByMasterQuery : IRequest<List<SelectListItem>>
    {
        public long MasterID { get; set; }
        public int GatePassDetailID { get; set; }
    }
    public class GetDDLIssuance_DetailByMasterQueryHandler : IRequestHandler<GetDDLIssuance_DetailByMasterQuery, List<SelectListItem>>
    {
        private readonly ITbl_Issuance_MasterService tbl_Issuance_MasterService;
        public GetDDLIssuance_DetailByMasterQueryHandler(ITbl_Issuance_MasterService _tbl_Issuance_MasterService)
        {
            tbl_Issuance_MasterService = _tbl_Issuance_MasterService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLIssuance_DetailByMasterQuery request, CancellationToken cancellationToken)
        {
            return await tbl_Issuance_MasterService.GetDDLIssuance_DetailByMaster(request.MasterID, request.GatePassDetailID, cancellationToken);
        }
    }
}
