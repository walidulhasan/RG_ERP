using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_POMaster.Queries
{
    public class GetDDLYarnPONoQuery : IRequest<List<SelectListItem>>
    {
        public int SupplierID { get; set; }
        public DateTime PODateFrom { get; set; }
        public DateTime PODateTo { get; set; }
        public string Predict { get; set; } = null;
    }
    public class GetDDLYarnPONoQueryHandler : IRequestHandler<GetDDLYarnPONoQuery, List<SelectListItem>>
    {
        private readonly IYarn_POMasterService _yarn_POMasterService;

        public GetDDLYarnPONoQueryHandler(IYarn_POMasterService yarn_POMasterService)
        {
            _yarn_POMasterService = yarn_POMasterService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLYarnPONoQuery request, CancellationToken cancellationToken)
        {
            return await _yarn_POMasterService.DDLYarnPONo(request.SupplierID, request.PODateFrom,request.PODateTo,request.Predict, cancellationToken);
        }
    }
}
