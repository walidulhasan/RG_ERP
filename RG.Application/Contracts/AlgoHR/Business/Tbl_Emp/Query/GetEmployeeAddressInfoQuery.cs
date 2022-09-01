using MediatR;
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
    public class GetEmployeeAddressInfoQuery : IRequest<EmployeeAddressInfoRM>
    {
        public string EmployeeCode { get; set; }
    }
    public class GetEmployeeAddressInfoQueryHandler : IRequestHandler<GetEmployeeAddressInfoQuery, EmployeeAddressInfoRM>
    {
        private readonly ITbl_EmpService _tbl_EmpService;

        public GetEmployeeAddressInfoQueryHandler(ITbl_EmpService tbl_EmpService)
        {
            _tbl_EmpService = tbl_EmpService;
        }
        public async Task<EmployeeAddressInfoRM> Handle(GetEmployeeAddressInfoQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpService.GetEmployeeAddressInfo(request.EmployeeCode, cancellationToken);
        }
    }
}
