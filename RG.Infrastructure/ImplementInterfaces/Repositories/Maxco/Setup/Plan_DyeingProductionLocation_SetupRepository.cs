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
   public class Plan_DyeingProductionLocation_SetupRepository :GenericRepository<Plan_DyeingProductionLocation_Setup>, IPlan_DyeingProductionLocation_SetupRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public Plan_DyeingProductionLocation_SetupRepository(MaxcoDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }
    }
}
