using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Commands.Create
{
    public class PlanOrderMasterCreateCommand:IRequest<RResult>
    {
        public Plan_OrderMaster PlanOrderMaster { get; set; }
    }
    public class PlanOrderMasterCreateCommandRequest : IRequestHandler<PlanOrderMasterCreateCommand, RResult>
    {
        private readonly IPlan_OrderMasterService plan_OrderMasterService;

        public PlanOrderMasterCreateCommandRequest(IPlan_OrderMasterService _plan_OrderMasterService)
        {
            plan_OrderMasterService = _plan_OrderMasterService;
        }
        public async Task<RResult> Handle(PlanOrderMasterCreateCommand request, CancellationToken cancellationToken)
        {
            return await plan_OrderMasterService.PlanOrderMasterSave(request.PlanOrderMaster);
        }
    }
}
