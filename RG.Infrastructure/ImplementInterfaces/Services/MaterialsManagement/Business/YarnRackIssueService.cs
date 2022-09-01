using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class YarnRackIssueService : IYarnRackIssueService
    {
        private readonly IYarnRackIssueRepository _yarnRackIssueRepository;

        public YarnRackIssueService(IYarnRackIssueRepository yarnRackIssueRepository)
        {
            _yarnRackIssueRepository = yarnRackIssueRepository;
        }
        public async Task<RResult> YarnRackIssueSave(List<YarnRackIssue> entities, bool saveChanges = true)
        {
            return await _yarnRackIssueRepository.YarnRackIssueSave(entities, saveChanges);
        }
    }
}
