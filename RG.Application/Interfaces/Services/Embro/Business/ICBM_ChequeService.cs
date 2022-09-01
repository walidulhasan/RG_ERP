using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Business
{
    public interface ICBM_ChequeService
    {
        Task<List<SelectListItem>> DDLSupplierWhomChequePaidTo(int accountID, DateTime fromDate, DateTime toDate, string predict, CancellationToken cancellationToken);
    }
}
