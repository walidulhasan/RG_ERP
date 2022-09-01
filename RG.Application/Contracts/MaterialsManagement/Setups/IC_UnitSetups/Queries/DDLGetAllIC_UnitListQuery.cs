using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_UnitSetups.Queries
{
    public class DDLGetAllIC_UnitListQuery : IRequest<List<SelectListItem>>
    {
        public List<string> WithShortName { get; set; } = null;
    }
    public class DDLGetAllIC_UnitListQueryHandler : IRequestHandler<DDLGetAllIC_UnitListQuery, List<SelectListItem>>
    {
        private readonly IIC_UnitSetupService iC_UnitSetupService;

        public DDLGetAllIC_UnitListQueryHandler(IIC_UnitSetupService _iC_UnitSetupService)
        {
            iC_UnitSetupService = _iC_UnitSetupService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetAllIC_UnitListQuery request, CancellationToken cancellationToken)
        {
            return await iC_UnitSetupService.DDLGetAllIC_UnitList(request.WithShortName, cancellationToken);
        }
    }
}
