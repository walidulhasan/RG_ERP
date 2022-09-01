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
    public class Plan_ArtWork_SetupRepository :GenericRepository<Plan_ArtWork_Setup>, IPlan_ArtWork_SetupRepository
    {
        private readonly MaxcoDBContext _dbCon;
        public Plan_ArtWork_SetupRepository(MaxcoDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;

        }
    }
}
