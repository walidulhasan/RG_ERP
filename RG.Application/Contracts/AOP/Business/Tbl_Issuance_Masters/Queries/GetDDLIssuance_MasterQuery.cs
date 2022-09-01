using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AOP.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries
{
    public class GetDDLIssuance_MasterQuery : IRequest<List<SelectListItem>>
    {
        public int SupplierID { get; set; }
        public int GatePassDetailID { get; set; }
        public string Predict { get; set; }

    }
    public class GetDDLIssuance_MasterQueryHandler : IRequestHandler<GetDDLIssuance_MasterQuery, List<SelectListItem>>
    {
        private readonly ITbl_Issuance_MasterService tbl_Issuance_MasterService;
        public GetDDLIssuance_MasterQueryHandler(ITbl_Issuance_MasterService _tbl_Issuance_MasterService)
        {
            tbl_Issuance_MasterService = _tbl_Issuance_MasterService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLIssuance_MasterQuery request, CancellationToken cancellationToken)
        {
            return await tbl_Issuance_MasterService.GetDDLIssuance_Master(request.SupplierID, request.GatePassDetailID, request.Predict);
        }
    }
}
