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

namespace RG.Application.Contracts.AlgoHR.Business.EmployeeLeaveCancels.Commands.Create
{
    public class EmployeeLeaveCancelCreateCommand:IRequest<RResult>
    {
        public EmployeeLeaveCancelVM employeeLeaveCancelVM { get; set; }
    }
    public class EmployeeLeaveCancelCreateCommandHandler : IRequestHandler<EmployeeLeaveCancelCreateCommand, RResult>
    {
        private readonly IEmployeeLeaveCancelService _employeeLeaveCancelService;

        public EmployeeLeaveCancelCreateCommandHandler(IEmployeeLeaveCancelService employeeLeaveCancelService)
        {
            _employeeLeaveCancelService = employeeLeaveCancelService;
        }
        public async Task<RResult> Handle(EmployeeLeaveCancelCreateCommand request, CancellationToken cancellationToken)
        {
            return await _employeeLeaveCancelService.Create(request.employeeLeaveCancelVM,true);
        }
    }
}
