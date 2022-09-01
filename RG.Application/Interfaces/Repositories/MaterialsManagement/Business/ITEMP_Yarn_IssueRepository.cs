using RG.Application.Common.Models;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface ITEMP_Yarn_IssueRepository:IGenericRepository<TEMP_Yarn_Issue>
    {
        Task<RResult> TEMP_Yarn_issueSave(List<TEMP_Yarn_Issue> entities, bool saveChanges = true);
    }
}
