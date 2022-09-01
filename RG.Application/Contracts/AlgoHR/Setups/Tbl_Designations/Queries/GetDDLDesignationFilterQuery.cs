using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Designations.Queries
{
    public class GetDDLDesignationFilterQuery : IRequest<List<SelectListItem>>
    {
        public List<int> OfficeDivisionID { get; set; }
        public List<int> DepartmentID { get; set; }
        public List<int> SectionID { get; set; }
        public string Predict { get; set; }
    }

    public class GetDDLDesignationFilterQueryHandler : IRequestHandler<GetDDLDesignationFilterQuery, List<SelectListItem>>
    {
        private readonly ITbl_DesignationService _tbl_DesignationService;
        public GetDDLDesignationFilterQueryHandler(ITbl_DesignationService tbl_DesignationService)
        {
            _tbl_DesignationService = tbl_DesignationService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLDesignationFilterQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_DesignationService.DDLDesignation(request.OfficeDivisionID, request.DepartmentID, request.SectionID, request.Predict, cancellationToken);
        }
    }
}
