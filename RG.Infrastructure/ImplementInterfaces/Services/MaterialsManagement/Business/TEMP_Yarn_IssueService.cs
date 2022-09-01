using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class TEMP_Yarn_IssueService : ITEMP_Yarn_IssueService
    {
        private readonly ITEMP_Yarn_IssueRepository _tEMP_Yarn_IssueRepository;

        public TEMP_Yarn_IssueService(ITEMP_Yarn_IssueRepository tEMP_Yarn_IssueRepository)
        {
            _tEMP_Yarn_IssueRepository = tEMP_Yarn_IssueRepository;
        }
        public async Task<RResult> TEMP_Yarn_issueSave(List<YKNCBatchDTM> models, bool saveChanges = true)
        {
            List<TEMP_Yarn_Issue> entities = new();
            models.ForEach(x =>entities.Add(new TEMP_Yarn_Issue {
               YKNC=(int)x.YarnKnittingContractID,
               AtributeInstanceID=(int)x.AttributeInstanceID,
               Quantity=(int)x.AllocatedYarnIssueFromRack.Sum(c=>c.IssuedQuantity),
               LotNo=x.LotNo,
               YarnAttributeInstanceID=x.YarnAttributeInstanceID,
               IssuanceTime=DateTime.Now
            }));
            return await _tEMP_Yarn_IssueRepository.TEMP_Yarn_issueSave(entities, saveChanges);
        }
    }
}
