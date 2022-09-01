using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Sections.Queries
{
    public class GetDDLTbl_SectionQuery : IRequest<List<SelectListItem>>
    {
        public GetDDLTbl_SectionQuery()
        {
            DepartmentID = new List<int>();
        }
        public List<int> DepartmentID { get; set; }
        public string Predict { get; set; }
    }

    public class GetDDLTbl_SectionQueryHandler : IRequestHandler<GetDDLTbl_SectionQuery, List<SelectListItem>>
    {
        private readonly ITbl_SectionService _tbl_SectionService;

        public GetDDLTbl_SectionQueryHandler(ITbl_SectionService tbl_SectionService)
        {
            _tbl_SectionService = tbl_SectionService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLTbl_SectionQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_SectionService.DDLSection(request.DepartmentID, request.Predict, cancellationToken);
        }
    }
}
