using AutoMapper;
using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.Create
{
    public class IC_UserDepartmentSetupCreateCommand : IRequest<RResult>
    {
        public List<IC_UserDepartmentSetupDTM> UserDepartmentSetup { get; set; }
    }
    public class IC_UserDepartmentSetupCreateCommandHandler : IRequestHandler<IC_UserDepartmentSetupCreateCommand, RResult>
    {
        private readonly IMapper mapper;
        private readonly IIC_UserDepartmentSetupService iC_UserDepartmentSetupService;

        public IC_UserDepartmentSetupCreateCommandHandler(IMapper _mapper, IIC_UserDepartmentSetupService _iC_UserDepartmentSetupService)
        {
            mapper = _mapper;
            iC_UserDepartmentSetupService = _iC_UserDepartmentSetupService;
        }
        public async Task<RResult> Handle(IC_UserDepartmentSetupCreateCommand request, CancellationToken cancellationToken)
        {
            //var userWiseDepartmentAssDTM = mapper.Map<List<IC_UserDepartmentSetupQM>, List<IC_UserDepartmentSetupDTM>>(request.IC_UserDepartmentSetup);
            return await iC_UserDepartmentSetupService.SaveUserWiseDepartmentAssaign(request.UserDepartmentSetup, cancellationToken);

        }
    }
}
