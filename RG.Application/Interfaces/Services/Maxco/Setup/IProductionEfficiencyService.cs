using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Commands.DataTransferModel;
using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Queries.RequestRespondeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Setup
{
    public  interface IProductionEfficiencyService
    {
        Task<RResult> SaveAndUpdate(ProductionEfficiencyDTM model);
        Task<RResult> Remove(int id, bool saveChange);
        IQueryable<ProductionEfficiencyRM> GetAllGridData();
    }
}
