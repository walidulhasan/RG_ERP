using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.Update
{
    public class ProductionEfficencyRemoveCommand:IRequest<RResult>
    {
        public int ID { get; set; }

    }
    public class ProductionEfficencyRemoveCommandHandler : IRequestHandler<ProductionEfficencyRemoveCommand, RResult>
    {
        private readonly IProductionEfficiencyService _productionEfficiencyService;

        public ProductionEfficencyRemoveCommandHandler(IProductionEfficiencyService productionEfficiencyService)
        {
            _productionEfficiencyService = productionEfficiencyService;
        }
        public async Task<RResult> Handle(ProductionEfficencyRemoveCommand request, CancellationToken cancellationToken)
        {
            return await _productionEfficiencyService.Remove(request.ID, true);
        }
    }
}
