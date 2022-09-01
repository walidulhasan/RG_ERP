using RG.Application.Common.Models;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.MaterialsManagement.Business
{
    public interface IYarnRackIssueRepository:IGenericRepository<YarnRackIssue>
    {
        Task<RResult> YarnRackIssueSave(List<YarnRackIssue> entities, bool saveChanges = true);
    }
}
