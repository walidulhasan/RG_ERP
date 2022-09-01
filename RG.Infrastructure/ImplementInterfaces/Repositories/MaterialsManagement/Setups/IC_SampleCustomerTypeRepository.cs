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
    public class IC_SampleCustomerTypeRepository : GenericRepository<IC_SampleCustomerType>, IIC_SampleCustomerTypeRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public IC_SampleCustomerTypeRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLSampleCustomerType(CancellationToken cancellationToken = default)
        {
            var list = await dbCon.IC_SampleCustomerType.Where(b => b.IsActive == true)
                .Select(b => new SelectListItem
                {
                    Text = b.CustomerType,
                    Value = b.ID.ToString()
                }).ToListAsync(cancellationToken);

            return list;
        }
    }
}
