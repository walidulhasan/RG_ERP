using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Queries.RequestRespondeModel;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Setup
{
    public interface IProductionEfficiencyRepository :IGenericRepository<GarmentsProductionEfficiency>
    {
        IQueryable<ProductionEfficiencyRM> GetAllGridData();
    }
}
