using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query
{

    public class GetDDLEmployeeByAdvanceFilterQuery :IRequest<List<SelectListItem>>
    {
        public EmployeeDDLAdvanceFilterQM Filter { get; set; }
        /// <summary>
        /// Employee ID OR Code
        /// </summary>
        public string DPValue { get; set; } = "ID";
    }
    public class GetDDLEmployeeByAdvanceFilterQueryHandler : IRequestHandler<GetDDLEmployeeByAdvanceFilterQuery, List<SelectListItem>>
    {
        private readonly ITbl_EmpService _tbl_EmpService;

        public GetDDLEmployeeByAdvanceFilterQueryHandler(ITbl_EmpService tbl_EmpService)
        {
            _tbl_EmpService = tbl_EmpService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLEmployeeByAdvanceFilterQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpService.GetDDLEmployeeByAdvanceFilter(request.Filter, request.DPValue, cancellationToken);
        }
    }
}
