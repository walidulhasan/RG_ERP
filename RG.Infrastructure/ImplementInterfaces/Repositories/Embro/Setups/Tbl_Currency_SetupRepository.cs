using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.Embro.Setups.Tbl_Currency_Setups.Querirs.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class Tbl_Currency_SetupRepository : GenericRepository<tbl_Currency_Setup>, ITbl_Currency_SetupRepository
    {
        private readonly EmbroDBContext _dbcon;

        public Tbl_Currency_SetupRepository(EmbroDBContext context) : base(context)
        {
            _dbcon = context;
        }
        public async Task<CurrencyInfoRM> GetCurrencyRate(long CurrencyID)
        {
            var rate = await _dbcon.tbl_Currency_Detail.Where(b => b.CurId == CurrencyID)
                .OrderByDescending(b => b.Date)
                .Select(s => new CurrencyRateRM()
                {
                    CurId = s.CurId,
                    Date = s.Date,
                    RateInBDT = s.RateInPakRs,
                    ID = s.ID
                }).FirstOrDefaultAsync();

            var cur = await _dbcon.tbl_Currency_Setup
                .Where(b => b.ID == CurrencyID)
                .Select(s => new CurrencyInfoRM()
                {
                    ID = s.ID,
                    CountryName = s.countryName,
                    CurrencyName = s.currencyName,
                    ShortName = s.ShortName,
                    Symbol = s.Symbol
                })
                .FirstOrDefaultAsync();
            cur.CurrencyRate = rate;

            return cur;


        }
    }
}
