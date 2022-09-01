using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface IERP_PaymentModesService
    {
        Task<List<SelectListItem>> GetDDLERP_PaymentModes(CancellationToken cancellationToken);
    }
}
