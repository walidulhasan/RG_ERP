using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_ReturnableRecieveGatePassDetails.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class IC_ReturnableGatePassDetailService : IIC_ReturnableGatePassDetailService
    {
        private readonly IIC_ReturnableGatePassDetailRepository iC_ReturnableGatePassDetailRepository;

        public IC_ReturnableGatePassDetailService(IIC_ReturnableGatePassDetailRepository _iC_ReturnableGatePassDetailRepository)
        {
            iC_ReturnableGatePassDetailRepository = _iC_ReturnableGatePassDetailRepository;
        }
        public async Task<RResult> ReturnableGatePassDetailReceivedQuantityUpdate(List<IC_ReturnableRecieveGatePassDetailDTM> model, CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();
            foreach (var item in model)
            {
                var entity = await iC_ReturnableGatePassDetailRepository.GetByIdAsync(item.ReturnableGatePassItemID);
                entity.RecieveQuantity = entity.RecieveQuantity == null ? item.RecieveQuantity : (entity.RecieveQuantity + item.RecieveQuantity);
                entity.WastageQuantity = entity.WastageQuantity == null ? item.WastageQuantity : (entity.WastageQuantity + item.WastageQuantity);

                if ((entity.Quantity == 0 ? entity.GrossWeight : entity.Quantity) >= (entity.RecieveQuantity + entity.WastageQuantity))
                {
                    rResult = await iC_ReturnableGatePassDetailRepository.UpdateIC_ReturnableGatePassDetail(entity, cancellationToken);
                }
            }
            return rResult;
        }
    }
}
