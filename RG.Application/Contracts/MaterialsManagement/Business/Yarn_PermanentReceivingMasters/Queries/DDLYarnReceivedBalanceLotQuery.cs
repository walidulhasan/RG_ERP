using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.Yarn_PermanentReceivingMasters.Queries
{
    public class DDLYarnReceivedBalanceLotQuery : IRequest<List<SelectListItem>>
    {
        public long SupplierID { get; set; } = 0;
        public long POID { get; set; } = 0;
        public int TopData { get; set; } = 500;
        public string Predict { get; set; } = null;
    }
    public class DDLYarnReceivedBalanceLotQueryHandler : IRequestHandler<DDLYarnReceivedBalanceLotQuery, List<SelectListItem>>
    {
        private readonly IYarn_PermanentReceivingMasterService _yarn_PermanentReceivingMasterService;

        public DDLYarnReceivedBalanceLotQueryHandler(IYarn_PermanentReceivingMasterService yarn_PermanentReceivingMasterService )
        {
            _yarn_PermanentReceivingMasterService = yarn_PermanentReceivingMasterService;
        }
        public async Task<List<SelectListItem>> Handle(DDLYarnReceivedBalanceLotQuery request, CancellationToken cancellationToken)
        {
            return await _yarn_PermanentReceivingMasterService.DDLYarnReceivedBalanceLot(request.SupplierID, request.POID, request.TopData, request.Predict, cancellationToken);
        }
    }
}
