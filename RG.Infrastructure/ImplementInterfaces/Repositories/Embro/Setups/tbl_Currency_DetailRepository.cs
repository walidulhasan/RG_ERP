using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class tbl_Currency_DetailRepository : GenericRepository<tbl_Currency_Detail>, Itbl_Currency_DetailRepository
    {
        private EmbroDBContext dbCon;

        public tbl_Currency_DetailRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<tbl_Currency_Detail> GetCurrencyRate(long CurrencyId, CancellationToken cancellationToken)
        {
            try
            {
                var data = await dbCon.tbl_Currency_Detail.Where(b => b.CurId == CurrencyId)
                     .Select(b => new tbl_Currency_Detail
                     {
                         CurId = b.CurId.Value,
                         Date = b.Date,
                         EnteredBy = b.EnteredBy,
                         RateInPakRs = b.RateInPakRs

                     }).OrderByDescending(x => x.Date).FirstAsync(cancellationToken);

                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
