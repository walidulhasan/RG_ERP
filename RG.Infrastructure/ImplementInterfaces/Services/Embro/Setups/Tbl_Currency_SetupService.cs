using RG.Application.Contracts.Embro.Setups.Tbl_Currency_Setups.Querirs.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class Tbl_Currency_SetupService : ITbl_Currency_SetupService
    {
        private readonly ITbl_Currency_SetupRepository _tbl_Currency_SetupRepository;

        public Tbl_Currency_SetupService(ITbl_Currency_SetupRepository tbl_Currency_SetupRepository)
        {
            _tbl_Currency_SetupRepository = tbl_Currency_SetupRepository;
        }
        public async Task<CurrencyInfoRM> GetCurrencyRate(long CurrencyID)
        {
            return await _tbl_Currency_SetupRepository.GetCurrencyRate(CurrencyID);
        }
    }
}
