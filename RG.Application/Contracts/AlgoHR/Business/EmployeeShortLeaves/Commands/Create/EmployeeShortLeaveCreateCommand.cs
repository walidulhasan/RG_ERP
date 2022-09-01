using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeShortLeave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.EmployeeShortLeaves.Commands.Create
{
    public class EmployeeShortLeaveCreateCommand:IRequest<RResult>
    {
        public ShortLeaveCreateVM ShortLeave { get; set; }
    }
    public class EmployeeShortLeaveCreateCommandHandler : IRequestHandler<EmployeeShortLeaveCreateCommand, RResult>
    {
        private readonly IEmployeeShortLeaveService _employeeShortLeaveService;

        public EmployeeShortLeaveCreateCommandHandler(IEmployeeShortLeaveService employeeShortLeaveService)
        {
            _employeeShortLeaveService = employeeShortLeaveService;
        }
        public async Task<RResult> Handle(EmployeeShortLeaveCreateCommand request, CancellationToken cancellationToken)
        {
            return await _employeeShortLeaveService.EmployeeShortLeaveCreate(request.ShortLeave, true);
        }
    }
}
