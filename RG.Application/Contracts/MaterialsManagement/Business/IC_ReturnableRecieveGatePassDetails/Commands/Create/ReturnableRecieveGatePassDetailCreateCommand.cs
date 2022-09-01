using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_ReturnableRecieveGatePassDetails.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_ReturnableRecieveGatePassDetails.Commands.Create
{
    public class ReturnableRecieveGatePassDetailCreateCommand : IRequest<RResult>
    {
        public List<IC_ReturnableRecieveGatePassDetailDTM> ReturnableRecieveGatePassDetail { get; set; }
    }
    public class ReturnableGatePassReceiveHistoryCreateCommandHandler : IRequestHandler<ReturnableRecieveGatePassDetailCreateCommand, RResult>
    {
        private readonly IIC_ReturnableRecieveGatePassDetailService returnableRecieveGatePassDetailService;

        public ReturnableGatePassReceiveHistoryCreateCommandHandler(IIC_ReturnableRecieveGatePassDetailService _ReturnableRecieveGatePassDetailService)
        {
            returnableRecieveGatePassDetailService = _ReturnableRecieveGatePassDetailService;
        }
        public async Task<RResult> Handle(ReturnableRecieveGatePassDetailCreateCommand request, CancellationToken cancellationToken)
        {
            return await returnableRecieveGatePassDetailService.SaveReturnableRecieveGatePassDetail(request.ReturnableRecieveGatePassDetail, cancellationToken);
        }
    }
}
