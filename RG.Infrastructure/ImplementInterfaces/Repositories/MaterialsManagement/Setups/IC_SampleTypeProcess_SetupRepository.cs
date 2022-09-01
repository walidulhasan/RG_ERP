using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
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
    public class IC_SampleTypeProcess_SetupRepository : GenericRepository<IC_SampleTypeProcess_Setup>, IIC_SampleTypeProcess_SetupRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public IC_SampleTypeProcess_SetupRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<List<DropDownItem>> DDLCustomSampleTypeProcess(int SampleTypeID, CancellationToken cancellationToken = default)
        {
            var query = QueryableDDLSampleTypeProcess(SampleTypeID);
            var data = await query.Select(s => new DropDownItem
            {
                Text = s.SampleProcessType,
                Value = s.SampleTypeProcessID.ToString(),
                Custom1 = s.SampleTypeID.ToString()
            }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLSampleTypeProcess(int SampleTypeID, CancellationToken cancellationToken = default)
        {
            var query = QueryableDDLSampleTypeProcess(SampleTypeID);
            var data = await query.Select(s => new SelectListItem
            {
                Text = s.SampleProcessType,
                Value = s.SampleTypeProcessID.ToString()
            }).ToListAsync(cancellationToken);
            return data;
        }
        private IQueryable<IC_SampleTypeProcess_Setup> QueryableDDLSampleTypeProcess(int SampleTypeID)
        {
            var query = dbCon.IC_SampleTypeProcess_Setup.Where(b => b.IsActive == true);
            if (SampleTypeID > 0)
            {
                query = query.Where(x => x.SampleTypeID == SampleTypeID);
            }
            return query;
        }
    }
}
