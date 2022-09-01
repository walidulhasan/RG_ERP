using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Divisions.Query
{
    public class GetDDLTbl_DivisionQuery : IRequest<List<SelectListItem>>
    {
        public GetDDLTbl_DivisionQuery()
        {
            EmbroCompanyID = new List<int>();
            ExceptDivision = new List<int>();
        }
        public List<int> EmbroCompanyID { get; set; }
        public List<int> ExceptDivision { get; set; }
        public string Predict { get; set; }
    }
    public class GetDDLTbl_DivisionQueryHandler : IRequestHandler<GetDDLTbl_DivisionQuery, List<SelectListItem>>
    {
        private readonly ITbl_DivisionService _tbl_DivisionService;

        public GetDDLTbl_DivisionQueryHandler(ITbl_DivisionService tbl_DivisionService)
        {
            _tbl_DivisionService = tbl_DivisionService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLTbl_DivisionQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_DivisionService.DDLDivision(request.EmbroCompanyID, request.ExceptDivision, request.Predict, cancellationToken);
        }
    }
}
