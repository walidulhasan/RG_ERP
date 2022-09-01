using RG.Application.Contracts.Embro.Setups.Tbl_Currency_Setups.Querirs.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface ITbl_Currency_SetupService
    {
        Task<CurrencyInfoRM> GetCurrencyRate(long CurrencyID);
    }
}
