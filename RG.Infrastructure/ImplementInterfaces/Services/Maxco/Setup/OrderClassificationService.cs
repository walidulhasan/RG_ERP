using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Setup
{
    public class OrderClassificationService : IOrderClassificationService
    {
        private readonly IOrderClassificationRepository orderClassificationRepository;

        public OrderClassificationService(IOrderClassificationRepository _orderClassificationRepository)
        {
            orderClassificationRepository = _orderClassificationRepository;
        }
        public async Task<List<SelectListItem>> DDLOrderClassification(CancellationToken cancellationToken)
        {
            return await orderClassificationRepository.DDLOrderClassification(cancellationToken);
        }
    }
}