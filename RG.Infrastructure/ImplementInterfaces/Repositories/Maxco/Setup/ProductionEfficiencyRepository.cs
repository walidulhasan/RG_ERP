using RG.Application.Contracts.Maxco.Setup.Production_Efficiency.Queries.RequestRespondeModel;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.DBEntities.Maxco.Setup;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Setup
{
    public class ProductionEfficiencyRepository : GenericRepository<GarmentsProductionEfficiency>, IProductionEfficiencyRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public ProductionEfficiencyRepository(MaxcoDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }

        public IQueryable<ProductionEfficiencyRM> GetAllGridData()
        {
            var query = _dbCon.GarmentsProductionEfficiency
                        .Where(x=> x.IsActive == true && x.IsRemoved == false )
                        .Select(r=> new ProductionEfficiencyRM()
                        {
                            ID=r.ID,
                            ProductionDate=r.ProductionDate,
                            StandardEfficiencyPercent=r.StandardEfficiencyPercent,
                            OverAllEfficiencyPercent=r.OverAllEfficiencyPercent
                        });
            return query;
        }
    }
}
