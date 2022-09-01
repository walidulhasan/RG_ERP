using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups
{
    public class IC_SampleType_SetupRepository : GenericRepository<IC_SampleType_Setup>, IIC_SampleType_SetupRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public IC_SampleType_SetupRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLSampleType_Setup(CancellationToken cancellationToken = default)
        {
            var rlist = await dbCon.IC_SampleType_Setup.Where(b => b.IsActive == true)
               .Select(s => new SelectListItem
               {
                   Text = s.SampleType,
                   Value = s.SampleTypeID.ToString()
               }).ToListAsync(cancellationToken);

            return rlist;
        }
    }
}
