using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.Tbl_Emp.Commands.Update
{
    public class EmployeePersonalInfoUpdateCommand:IRequest<RResult>
    {
        public EmployeePersonalInfoDTM PersonalInfo { get; set; }
    }
    public class EmployeePersonalInfoUpdateCommandHandler : IRequestHandler<EmployeePersonalInfoUpdateCommand, RResult>
    {
        private readonly ITbl_EmpService _tbl_EmpService;

        public EmployeePersonalInfoUpdateCommandHandler(ITbl_EmpService tbl_EmpService)
        {
            _tbl_EmpService = tbl_EmpService;
        }
        
        public async Task<RResult> Handle(EmployeePersonalInfoUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _tbl_EmpService.UpdateEmployeePersonalInfo(request.PersonalInfo, cancellationToken);
        }
    }
}
