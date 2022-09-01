using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel;
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
    public class Yarn_AllocationToKnitterService : IYarn_AllocationToKnitterService
    {
        private readonly IYarn_AllocationToKnitterRepository yarn_AllocationToKnitterRepository;
        public Yarn_AllocationToKnitterService(IYarn_AllocationToKnitterRepository _yarn_AllocationToKnitterRepository)
        {
            yarn_AllocationToKnitterRepository = _yarn_AllocationToKnitterRepository;
        }
        public async Task<List<DropDownItem>> GetDDLYarnRequisitionAfterAllocation(int KnitterID, int GatePassDetailID, string Predict, DateTime? DateFrom)
        {
            return await yarn_AllocationToKnitterRepository.GetDDLYarnRequisitionAfterAllocation(KnitterID, GatePassDetailID, Predict, DateFrom);
        }
        public async Task<List<SelectListItem>> GetDDL_Order_WaitingForYarnIssue(DateTime dateFrom, DateTime dateTo, string predict = null, CancellationToken cancellationToken = default)
        {
            return await yarn_AllocationToKnitterRepository.GetDDL_Order_WaitingForYarnIssue(dateFrom, dateTo, predict, cancellationToken);
        }
        public async Task<List<SelectListItem>> GetDDL_KRS_WaitingForYarnIssue(DateTime dateFrom, DateTime dateTo, int orderID = 0, string predict = null, CancellationToken cancellationToken = default)
        {
            return await yarn_AllocationToKnitterRepository.GetDDL_KRS_WaitingForYarnIssue(dateFrom, dateTo,orderID, predict, cancellationToken);
        }        

        public async Task<List<SelectListItem>> GetDDL_YKNC_WaitingForYarnIssue(DateTime dateFrom, DateTime dateTo, int orderID = 0, int krsID = 0, string predict = null, CancellationToken cancellationToken = default)
        {
            return await yarn_AllocationToKnitterRepository.GetDDL_YKNC_WaitingForYarnIssue(dateFrom, dateTo,orderID,krsID, predict, cancellationToken);
        }

        public async Task<YarnLotForIssuanceRM> GetYarnLotForIssuance(long ykncID, CancellationToken cancellationToken)
        {
            return await yarn_AllocationToKnitterRepository.GetYarnLotForIssuance(ykncID, cancellationToken);
        }
    }
}
