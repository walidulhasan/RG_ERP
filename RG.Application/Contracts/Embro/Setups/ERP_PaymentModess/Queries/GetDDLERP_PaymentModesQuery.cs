using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.ERP_PaymentModess.Queries
{
    public class GetDDLERP_PaymentModesQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLERP_PaymentModesQueryHandler : IRequestHandler<GetDDLERP_PaymentModesQuery, List<SelectListItem>>
    {
        private readonly IERP_PaymentModesService paymentModesService;

        public GetDDLERP_PaymentModesQueryHandler(IERP_PaymentModesService _PaymentModesService)
        {
            paymentModesService = _PaymentModesService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLERP_PaymentModesQuery request, CancellationToken cancellationToken)
        {
            return await paymentModesService.GetDDLERP_PaymentModes(cancellationToken);
        }
    }
}
