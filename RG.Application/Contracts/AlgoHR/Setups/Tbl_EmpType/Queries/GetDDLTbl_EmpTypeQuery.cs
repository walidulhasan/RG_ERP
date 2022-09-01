using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.Tbl_EmpType.Queries
{
    public class GetDDLTbl_EmpTypeQuery : IRequest<List<SelectListItem>>
    {

    }
    public class GetDDLTbl_EmpTypeQueryHandler : IRequestHandler<GetDDLTbl_EmpTypeQuery, List<SelectListItem>>
    {
        private readonly ITbl_EmpTypeService _tbl_EmpTypeService;

        public GetDDLTbl_EmpTypeQueryHandler(ITbl_EmpTypeService tbl_EmpTypeService)
        {
            _tbl_EmpTypeService = tbl_EmpTypeService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLTbl_EmpTypeQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpTypeService.DDLEmployeeType(cancellationToken);

        }
    }

}
