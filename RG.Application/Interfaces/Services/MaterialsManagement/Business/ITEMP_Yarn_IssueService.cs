using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface ITEMP_Yarn_IssueService
    {
        Task<RResult> TEMP_Yarn_issueSave(List<YKNCBatchDTM> entities, bool saveChanges = true);
    }
}
