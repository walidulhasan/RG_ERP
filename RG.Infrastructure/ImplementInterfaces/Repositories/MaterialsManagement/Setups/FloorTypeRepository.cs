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
    public class FloorTypeRepository : GenericRepository<FloorType>, IFloorTypeRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;

        public FloorTypeRepository(MaterialsManagementDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<SelectListItem>> GetDDLFloorType(CancellationToken cancellationToken)
        {
            var data =await (_dbCon.FloorType.Where(x => x.IsActive == true && x.IsRemoved == false)
                                        .Select(x => new SelectListItem
                                        {
                                            Text=x.FloorTypeName,
                                            Value=x.FloorTypeID.ToString()

                                        })).ToListAsync();
            return data;
        }
    }
}
