using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_ReturnableRecieveGatePassDetails.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface IIC_ReturnableGatePassDetailService
    {
        Task<RResult> ReturnableGatePassDetailReceivedQuantityUpdate(List<IC_ReturnableRecieveGatePassDetailDTM> model, CancellationToken cancellationToken);
    }
}
