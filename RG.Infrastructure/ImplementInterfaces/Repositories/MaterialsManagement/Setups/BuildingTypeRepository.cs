using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups
{
    public class BuildingTypeRepository : GenericRepository<BuildingType>, IBuildingTypeRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;

        public BuildingTypeRepository(MaterialsManagementDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<SelectListItem>> DDLBuildingType(CancellationToken cancellationToken)
        {
            var data = await(_dbCon.BuildingType.Where(x => x.IsActive == true && x.IsRemoved == false)
                      .Select(x => new SelectListItem
                      {
                          Text=x.BuildingTypeName,
                          Value=x.ID.ToString()

                      })).ToListAsync(cancellationToken);
            return data;
        }
    }
}
