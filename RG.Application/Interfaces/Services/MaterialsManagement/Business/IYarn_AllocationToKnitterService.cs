using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.Yarn_AllocationToKnitters.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface IYarn_AllocationToKnitterService
    {
        Task<List<DropDownItem>> GetDDLYarnRequisitionAfterAllocation(int KnitterID, int GatePassDetailID, string Predict, DateTime? DateFrom);
        Task<List<SelectListItem>> GetDDL_YKNC_WaitingForYarnIssue(DateTime dateFrom, DateTime dateTo, int orderID = 0, int krsID = 0, string predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> GetDDL_KRS_WaitingForYarnIssue(DateTime dateFrom, DateTime dateTo, int orderID = 0, string predict = null, CancellationToken cancellationToken = default);
        Task<List<SelectListItem>> GetDDL_Order_WaitingForYarnIssue(DateTime dateFrom, DateTime dateTo, string predict = null, CancellationToken cancellationToken = default);
        Task<YarnLotForIssuanceRM> GetYarnLotForIssuance(long ykncID, CancellationToken cancellationToken);
    }
}
