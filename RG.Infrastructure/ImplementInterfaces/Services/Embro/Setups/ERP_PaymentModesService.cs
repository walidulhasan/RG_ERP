using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class ERP_PaymentModesService : IERP_PaymentModesService
    {
        private readonly IERP_PaymentModesRepository paymentModesRepository;

        public ERP_PaymentModesService(IERP_PaymentModesRepository _PaymentModesRepository)
        {
            paymentModesRepository = _PaymentModesRepository;
        }
        public async Task<List<SelectListItem>> GetDDLERP_PaymentModes(CancellationToken cancellationToken)
        {
            return await paymentModesRepository.GetDDLERP_PaymentModes(cancellationToken);
        }
    }
}
