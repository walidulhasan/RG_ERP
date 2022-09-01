using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class AssetDepartmentRepository:GenericRepository<AssetDepartment>, IAssetDepartmentRepository
    {
        private readonly FiniteSchedulerDBContext _dbcon;

        public AssetDepartmentRepository(FiniteSchedulerDBContext dbcon):base(dbcon)
        {
            _dbcon = dbcon;
        }

        public async Task<List<SelectListItem>> GetDivisionWiseDDLDepartment(int DivisionWiseID, string Predict = null, CancellationToken cancellationToken = default)
        {
            var query = from ad in _dbcon.AssetDepartment
                        //join adv in _dbcon.AssetDivision on ad.DivisionID equals adv.DivisionID
                        where ad.DivisionID == DivisionWiseID
                        select new SelectListItem
                        {
                            Text = ad.DepartmentName,
                            Value = ad.DepartmentID.ToString(),

                        };
            var model = await query.ToListAsync(cancellationToken);
            return model;
        }
    }
}
