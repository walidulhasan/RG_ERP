using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface Itbl_Currency_DetailService
    {
        Task<tbl_Currency_Detail> GetCurrencyRate(long CurrencyId, CancellationToken cancellationToken);
    }
}
