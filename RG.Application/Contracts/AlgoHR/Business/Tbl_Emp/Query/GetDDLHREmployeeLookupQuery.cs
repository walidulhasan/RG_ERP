using MediatR;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Query
{
    public class GetDDLHREmployeeLookupQuery : IRequest<List<EmployeeBreakDownRM>>
    {
        public List<int> CompanyID { get; set; }
        public List<int> DivisionID { get; set; }
        public List<int> DepartmentID { get; set; }
        public List<int> SectionID { get; set; }
        public List<int> Designation { get; set; }
        public string Predict { get; set; }
    }

    public class GetDDLHREmployeeLookupQueryHandler : IRequestHandler<GetDDLHREmployeeLookupQuery, List<EmployeeBreakDownRM>>
    {
        private readonly ITbl_EmpService _tbl_EmpService;

        public GetDDLHREmployeeLookupQueryHandler(ITbl_EmpService tbl_EmpService)
        {
            _tbl_EmpService = tbl_EmpService;
        }
        public async Task<List<EmployeeBreakDownRM>> Handle(GetDDLHREmployeeLookupQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpService.DDLHREmployeeLookup(request.CompanyID, request.DivisionID, request.DepartmentID, request.SectionID, request.Designation, request.Predict, cancellationToken);
        }
    }


}
