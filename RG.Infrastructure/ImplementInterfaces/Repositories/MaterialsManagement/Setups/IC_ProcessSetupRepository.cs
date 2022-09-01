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
    public class IC_ProcessSetupRepository : GenericRepository<IC_ProcessSetup>, IIC_ProcessSetupRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public IC_ProcessSetupRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> GetDDLIC_ProcessSetup(CancellationToken cancellationToken = default)
        {
            var data = await dbCon.IC_ProcessSetup.Where(x => x.IsActive == true)
                .Select(s => new SelectListItem
                {
                    Text = s.ProcessName,
                    Value = s.ProcessID.ToString()
                }).ToListAsync(cancellationToken);
            return data;

        }
    }
}
