using RG.Application.Common.Models;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface IYarnRackIssueService
    {
        Task<RResult> YarnRackIssueSave(List<YarnRackIssue> entities, bool saveChanges = true);
    }
}
