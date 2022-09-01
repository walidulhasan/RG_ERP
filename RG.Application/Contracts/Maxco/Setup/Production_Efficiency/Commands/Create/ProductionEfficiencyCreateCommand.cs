using MediatR;
using RG.Application.Common.Mappings;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.Create
{
    public class ProductionEfficiencyCreateCommand:IRequest<RResult>
    {
        public ProductionEfficiencyDTM ProductionEfficiency { get; set; }
    }
    public class ProductionEfficiencyCreateCommandHandler : IRequestHandler<ProductionEfficiencyCreateCommand, RResult>
    {
        private readonly IProductionEfficiencyService _productionEfficiencyService;

        public ProductionEfficiencyCreateCommandHandler(IProductionEfficiencyService productionEfficiencyService)
        {
            _productionEfficiencyService = productionEfficiencyService;
        }
        public async Task<RResult> Handle(ProductionEfficiencyCreateCommand request, CancellationToken cancellationToken)
        {
            return await _productionEfficiencyService.SaveAndUpdate(request.ProductionEfficiency);
        }
    }
}
