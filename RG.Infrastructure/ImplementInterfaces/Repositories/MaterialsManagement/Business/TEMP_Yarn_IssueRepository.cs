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
    public class TEMP_Yarn_issueRepository:GenericRepository<TEMP_Yarn_Issue>, ITEMP_Yarn_IssueRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;

        public TEMP_Yarn_issueRepository(MaterialsManagementDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<RResult> TEMP_Yarn_issueSave(List<TEMP_Yarn_Issue> entities, bool saveChanges = true)
        {
            RResult rResult = new();
            await _dbCon.TEMP_Yarn_Issue.AddRangeAsync(entities);
            await _dbCon.SaveChangesAsync();
            return rResult;

        }
    }
}
