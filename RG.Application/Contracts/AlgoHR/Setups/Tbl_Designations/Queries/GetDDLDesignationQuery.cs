using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Designations.Queries
{
    public class GetDDLDesignationQuery : IRequest<List<SelectListItem>>
    {
        public int? OfficeDivisionID { get; set; }
        public int? DepartmentID { get; set; }
        public int? SectionID { get; set; }
    }
    public class GetDDLDesignationQueryHandler : IRequestHandler<GetDDLDesignationQuery, List<SelectListItem>>
    {
        private readonly ITbl_DesignationService _tbl_DesignationService;

        public GetDDLDesignationQueryHandler(ITbl_DesignationService tbl_DesignationService)
        {
            _tbl_DesignationService = tbl_DesignationService;
        }

        public async Task<List<SelectListItem>> Handle(GetDDLDesignationQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_DesignationService.DDLDesignation(request.OfficeDivisionID, request.DepartmentID, request.SectionID, cancellationToken);
        }
    }

}
