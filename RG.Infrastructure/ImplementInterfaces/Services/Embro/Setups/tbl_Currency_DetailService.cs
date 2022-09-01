using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Setups
{
    public class tbl_Currency_DetailService: Itbl_Currency_DetailService
    {
        private readonly Itbl_Currency_DetailRepository itbl_Currency_DetailRepository;
        public tbl_Currency_DetailService(Itbl_Currency_DetailRepository itbl_Currency_DetailRepository)
        {
            this.itbl_Currency_DetailRepository = itbl_Currency_DetailRepository;
        }

        public async Task<tbl_Currency_Detail> GetCurrencyRate(long CurrencyId, CancellationToken cancellationToken)
        {
            return await itbl_Currency_DetailRepository.GetCurrencyRate(CurrencyId,cancellationToken);
        }
    }
}
