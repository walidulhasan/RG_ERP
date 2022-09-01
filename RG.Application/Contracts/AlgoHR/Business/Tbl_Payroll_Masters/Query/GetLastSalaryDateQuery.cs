using MediatR;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Payroll_Masters.Query
{
    public class GetLastSalaryDateQuery : IRequest<DateTime?>
    {
    }
    public class GetLastSalaryDateQueryHandler : IRequestHandler<GetLastSalaryDateQuery, DateTime?>
    {
        private readonly ITbl_Payroll_MasterService _tbl_Payroll_MasterService;

        public GetLastSalaryDateQueryHandler(ITbl_Payroll_MasterService _tbl_Payroll_MasterService)
        {
            this._tbl_Payroll_MasterService = _tbl_Payroll_MasterService;
        }
        public async Task<DateTime?> Handle(GetLastSalaryDateQuery request, CancellationToken cancellationToken)
        {
            return await _tbl_Payroll_MasterService.GetLastSalaryDate(cancellationToken);
        }
    }
}
