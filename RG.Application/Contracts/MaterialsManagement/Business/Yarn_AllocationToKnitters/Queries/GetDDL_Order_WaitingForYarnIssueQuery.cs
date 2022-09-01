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
    public class GetDDL_Order_WaitingForYarnIssueQuery : IRequest<List<SelectListItem>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Predict { get; set; } = null;
    }
    public class GetDDL_Order_WaitingForYarnIssueQueryHandler : IRequestHandler<GetDDL_Order_WaitingForYarnIssueQuery, List<SelectListItem>>
    {
        private readonly IYarn_AllocationToKnitterService _yarn_AllocationToKnitterService;

        public GetDDL_Order_WaitingForYarnIssueQueryHandler(IYarn_AllocationToKnitterService yarn_AllocationToKnitterService)
        {
            _yarn_AllocationToKnitterService = yarn_AllocationToKnitterService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDL_Order_WaitingForYarnIssueQuery request, CancellationToken cancellationToken)
        {
            return await _yarn_AllocationToKnitterService.GetDDL_Order_WaitingForYarnIssue(request.DateFrom, request.DateTo, request.Predict, cancellationToken);
        }
    }
}
