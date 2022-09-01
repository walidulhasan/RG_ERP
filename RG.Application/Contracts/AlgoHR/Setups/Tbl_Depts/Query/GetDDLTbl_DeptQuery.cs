using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_Depts.Query
{
    public class GetDDLTbl_DeptQuery : IRequest<List<SelectListItem>>
    {
        public GetDDLTbl_DeptQuery()
        {
            DivisionID = new List<int>();
        }
        public List<int> DivisionID { get; set; }
        public string Predict { get; set; }
    }
    public class GetDDLTbl_DeptQueryHandler : IRequestHandler<GetDDLTbl_DeptQuery, List<SelectListItem>>
    {
        private readonly ITbl_DeptService _tbl_DeptService;

        public GetDDLTbl_DeptQueryHandler(ITbl_DeptService tbl_DeptService)
        {
            _tbl_DeptService = tbl_DeptService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLTbl_DeptQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_DeptService.DDLDept(request.DivisionID, request.Predict, cancellationToken);
        }
    }
}
