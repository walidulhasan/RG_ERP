using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Queries.RequestResponseModel;
using RG.DBEntities.MaterialsManagement.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Setups
{
    public interface IDailyProductionHourRepository : IGenericRepository<DailyProductionHour>
    {
        Task<int> MaxTableId();
        IQueryable<DailyProductionhourRM> GetAllGridData();
    }
}
