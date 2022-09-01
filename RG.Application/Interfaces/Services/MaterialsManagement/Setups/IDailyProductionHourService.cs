using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Setups.DailyProductionHour.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public  interface IDailyProductionHourService
    {
        Task<RResult> SaveAndUpdate(DailyProductionHourDTM model);
        Task<RResult> Remove(int ID, bool saveChange);
        public IQueryable<DailyProductionhourRM> GetAllGridData();
    }
}
