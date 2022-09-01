
using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups
{
    public class DailyProductionHourRepository : GenericRepository<DailyProductionHour>, IDailyProductionHourRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;

        public DailyProductionHourRepository(MaterialsManagementDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public IQueryable<DailyProductionhourRM> GetAllGridData()
        {
            var query = _dbCon.DailyProductionHours
                        .Where(x => x.IsActive == true && x.IsRemoved == false)
                        .Select(r => new DailyProductionhourRM()
                        {
                            ID = r.ID,
                            ProductionType = r.ProductionType,
                            TimeFrom = r.TimeFrom,
                            TimeTo = r.TimeTo,
                            LapTiming = r.LapTiming,
                            Description=r.Description

                        });
            return query;
        }

        public async Task<int> MaxTableId()
        {
            var maxValue = await _dbCon.DailyProductionHours
                .OrderByDescending(b => b.ID)
                .FirstOrDefaultAsync();
            if (maxValue == null)
            {
                return 1;
            }
            return maxValue.ID + 1;
        }
    }
}
