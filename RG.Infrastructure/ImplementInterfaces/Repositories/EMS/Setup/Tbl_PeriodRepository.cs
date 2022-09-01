using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.EMS.Setup;
using RG.DBEntities.EMS.Setup;
using RG.Infrastructure.Persistence.EMSDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.EMS.Setup
{
    public class Tbl_PeriodRepository : GenericRepository<Tbl_Period>, ITbl_PeriodRepository
    {
        private EMSDBContext dbCon;
        public Tbl_PeriodRepository(EMSDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<SelectListItem>> DDLWeekPeriod(int year, int month, CancellationToken cancellationToken)
        {
            var data = await dbCon.Tbl_Period
                        .Where(x => x.Period_Year == year && x.Period_Start != null
                                && (month == 0 || (x.Period_Start.HasValue && x.Period_Start.Value.Month == month)))
                        .Select(r => new SelectListItem
                        {
                            Text = r.Period_Name,
                            Value = r.Period_ID.ToString()
                        }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
