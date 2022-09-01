using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class YarnRackIssueRepository : GenericRepository<YarnRackIssue>, IYarnRackIssueRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public YarnRackIssueRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<RResult> YarnRackIssueSave(List<YarnRackIssue> entities, bool saveChanges = true)
        {
            RResult rResult = new();
            await dbCon.YarnRackIssue.AddRangeAsync(entities);
            await dbCon.SaveChangesAsync();
            return rResult;
        }
    }
}
