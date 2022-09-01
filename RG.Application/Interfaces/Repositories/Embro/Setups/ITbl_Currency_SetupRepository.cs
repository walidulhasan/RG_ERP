using RG.Application.Contracts.Embro.Setups.Tbl_Currency_Setups.Querirs.RequestResponseModel;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Setups
{
    public interface ITbl_Currency_SetupRepository :IGenericRepository<tbl_Currency_Setup>
    {
        Task<CurrencyInfoRM> GetCurrencyRate(long CurrencyID);
    }
}
