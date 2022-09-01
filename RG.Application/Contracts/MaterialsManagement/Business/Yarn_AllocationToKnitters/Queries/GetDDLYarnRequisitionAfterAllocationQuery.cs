using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries
{
    public class GetDDLYarnRequisitionAfterAllocationQuery : IRequest<List<DropDownItem>>
    {
        public int KnitterID { get; set; }
        public int GatePassDetailID { get; set; }
        public string Predict { get; set; }
        public DateTime? DateFrom { get; set; }
    }
    public class GetDDLYarnRequisitionAfterAllocationQueryHandler : IRequestHandler<GetDDLYarnRequisitionAfterAllocationQuery, List<DropDownItem>>
    {
        private readonly IYarn_AllocationToKnitterService yarn_AllocationToKnitterService;
        public GetDDLYarnRequisitionAfterAllocationQueryHandler(IYarn_AllocationToKnitterService _yarn_AllocationToKnitterService)
        {
            yarn_AllocationToKnitterService = _yarn_AllocationToKnitterService;
        }
        public async Task<List<DropDownItem>> Handle(GetDDLYarnRequisitionAfterAllocationQuery request, CancellationToken cancellationToken)
        {
            return await yarn_AllocationToKnitterService.GetDDLYarnRequisitionAfterAllocation(request.KnitterID, request.GatePassDetailID, request.Predict, request.DateFrom);
        }
    }
}
