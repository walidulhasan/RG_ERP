using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
    public class MT_Location_SetupRepository : GenericRepository<MT_Location_Setup>, IMT_Location_SetupRepository
    {
        private FiniteSchedulerDBContext dbCon;       
        public MT_Location_SetupRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;            
        }
        public async Task<List<SelectListItem>> DDLCompanyWiseLocation(int companyID, CancellationToken cancellationToken)
        {
            try
            {
                var data = await dbCon.MT_Location_Setup.Where(b => b.CompanyID == companyID)
                               .Select(b => new SelectListItem()
                               {
                                   Text = b.LocationName,
                                   Value = b.ID.ToString()
                               }).ToListAsync(cancellationToken);
                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }
    }
}
