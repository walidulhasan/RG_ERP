using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeLeaveCancel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_EmpLeavess.Commands.Update
{
    public class LeaveApplicationApprovedCancelAutoCommand:IRequest<RResult>
    {
        public EmployeeLeaveCancelVM employeeLeaveCancelVM { get; set; }
    }
    public class ApplicationCancelCommandHandlar : IRequestHandler<LeaveApplicationApprovedCancelAutoCommand, RResult>
    {
        private readonly ITbl_EmpLeavesService _tbl_EmpLeavesService;

        public ApplicationCancelCommandHandlar(ITbl_EmpLeavesService tbl_EmpLeavesService)
        {
            _tbl_EmpLeavesService = tbl_EmpLeavesService;
        }
        public async Task<RResult> Handle(LeaveApplicationApprovedCancelAutoCommand request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpLeavesService.ApplicationCancel(request.employeeLeaveCancelVM,cancellationToken);
        }
    }
}
