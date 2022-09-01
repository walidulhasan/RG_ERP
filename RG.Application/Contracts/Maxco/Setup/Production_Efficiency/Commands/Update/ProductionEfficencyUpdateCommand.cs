using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.Update
{
    public class ProductionEfficencyUpdateCommand:IRequest<RResult>
    {
        public ProductionEfficiencyDTM ProductionEfficency { get; set; }
        public bool UpdateChange { get; set; }
    }
    public class ProductionEfficencyUpdateCommandHandler : IRequestHandler<ProductionEfficencyUpdateCommand, RResult>
    {
        private readonly IProductionEfficiencyService _productionEfficiencyService;

        public ProductionEfficencyUpdateCommandHandler(IProductionEfficiencyService productionEfficiencyService)
        {
            _productionEfficiencyService = productionEfficiencyService;
        }
        public async Task<RResult> Handle(ProductionEfficencyUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _productionEfficiencyService.SaveAndUpdate(request.ProductionEfficency);
        }
    }
}
