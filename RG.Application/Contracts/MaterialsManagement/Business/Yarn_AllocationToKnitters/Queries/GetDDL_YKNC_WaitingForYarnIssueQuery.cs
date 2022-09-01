using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries
{
    public class GetDDL_YKNC_WaitingForYarnIssueQuery : IRequest<List<SelectListItem>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int OrderID { get; set; }
        public int KRSID { get; set; }
        public string Predict { get; set; } = null;
    }
    public class GetDDL_YKNC_WaitingForYarnIssueQueryHandler : IRequestHandler<GetDDL_YKNC_WaitingForYarnIssueQuery, List<SelectListItem>>
    {
        private readonly IYarn_AllocationToKnitterService _yarn_AllocationToKnitterService;

        public GetDDL_YKNC_WaitingForYarnIssueQueryHandler(IYarn_AllocationToKnitterService yarn_AllocationToKnitterService)
        {
            _yarn_AllocationToKnitterService = yarn_AllocationToKnitterService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDL_YKNC_WaitingForYarnIssueQuery request, CancellationToken cancellationToken)
        {
            return await _yarn_AllocationToKnitterService.GetDDL_YKNC_WaitingForYarnIssue(request.DateFrom, request.DateTo, request.OrderID,request.KRSID, request.Predict, cancellationToken);
        }
    }
}