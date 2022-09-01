using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.Create
{
    public class ScrapSalesGatePassCreateCommand : IRequest<RResult>
    {
        public ScrapSalesGatePassDTM ScrapSalesGatePass { get; set; }
    }
    public class ScrapSalesGatePassCreateCommandHandler : IRequestHandler<ScrapSalesGatePassCreateCommand, RResult>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;

        public ScrapSalesGatePassCreateCommandHandler(IIC_GatepassMasterService _iC_GatepassMasterService)
        {
            iC_GatepassMasterService = _iC_GatepassMasterService;
        }
        public async Task<RResult> Handle(ScrapSalesGatePassCreateCommand request, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterService.SaveScrapSales(request.ScrapSalesGatePass, cancellationToken);
        }
    }
}
