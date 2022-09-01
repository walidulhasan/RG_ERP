using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Business
{
    public interface ICBM_ChequeRepository:IGenericRepository<CBM_Cheque>
    {
        Task<List<SelectListItem>> DDLSupplierWhomChequePaidTo(int accountID, DateTime fromDate, DateTime toDate, string predict, CancellationToken cancellationToken);
    }
}
