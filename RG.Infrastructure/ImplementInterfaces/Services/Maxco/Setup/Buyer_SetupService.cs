using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Setup
{
    public class Buyer_SetupService : IBuyer_SetupService
    {
        private readonly IBuyer_SetupRepository buyer_SetupRepository;

        public Buyer_SetupService(IBuyer_SetupRepository _buyer_SetupRepository)
        {
            buyer_SetupRepository = _buyer_SetupRepository;
        }

        public async Task<List<SelectListItem>> DDLBuyerAllQuery(DateTime? OrderDateLimit = null, CancellationToken cancellationToken = default)
        {
            return await buyer_SetupRepository.DDLBuyerAllQuery(OrderDateLimit, cancellationToken);
        }

        public async Task<List<SelectListItem>> DDLBuyerOfPlannedOrders(CancellationToken cancellationToken)
        {
            return await buyer_SetupRepository.DDLBuyerOfPlannedOrders(cancellationToken);
        }
    }
}
