using MediatR;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Payroll_Masters.Query.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Payroll_Masters.Query
{
    public class GetSalaryPaySlipInfoQuery:IRequest<SalaryPaySlipRM>
    {
        public int EmployeeID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
    public class GetSalaryPaySlipInfoQueryHandler : IRequestHandler<GetSalaryPaySlipInfoQuery, SalaryPaySlipRM>
    {
        private readonly ITbl_Payroll_MasterService tbl_Payroll_MasterService;

        public GetSalaryPaySlipInfoQueryHandler(ITbl_Payroll_MasterService _tbl_Payroll_MasterService)
        {
            tbl_Payroll_MasterService = _tbl_Payroll_MasterService;
        }
        public async Task<SalaryPaySlipRM> Handle(GetSalaryPaySlipInfoQuery request, CancellationToken cancellationToken)
        {
            return await tbl_Payroll_MasterService.GetSalaryPaySlipInfo(request.EmployeeID, request.Month, request.Year, cancellationToken);
        }
    }
}
