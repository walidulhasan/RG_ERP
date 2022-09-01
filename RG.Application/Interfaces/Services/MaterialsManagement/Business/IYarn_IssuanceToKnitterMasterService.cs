using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface IYarn_IssuanceToKnitterMasterService
    {
        Task<RResult> IssuanceSave(AllocatedYarnIssueDTM model, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
