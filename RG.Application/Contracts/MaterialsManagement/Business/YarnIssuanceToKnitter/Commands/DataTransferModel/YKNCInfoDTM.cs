using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel
{
    public class YKNCInfoDTM
    {
        public List<AllocatedYarnIssueDTM> AllocatedYarnIssue { get; set; }
    }
}
