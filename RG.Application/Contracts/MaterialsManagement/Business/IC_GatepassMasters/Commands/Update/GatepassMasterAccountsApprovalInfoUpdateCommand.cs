using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatePassAccountReviews.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.Update
{
    public class GatepassMasterAccountsApprovalInfoUpdateCommand : IRequest<RResult>
    {
        public long GatePassID { get; set; }
        public bool IsApproved { get; set; }
        public IC_GatePassAccountReviewDTM AccountsReview { get; set; }
    }
    public class GatepassMasterAccountsApprovalInfoUpdateQueryHandler : IRequestHandler<GatepassMasterAccountsApprovalInfoUpdateCommand, RResult>
    {
        private readonly IIC_GatepassMasterService iC_GatepassMasterService;
        private readonly IIC_GatePassAccountReviewService iC_GatePassAccountReviewService;

        public GatepassMasterAccountsApprovalInfoUpdateQueryHandler(IIC_GatepassMasterService _iC_GatepassMasterService, IIC_GatePassAccountReviewService _iC_GatePassAccountReviewService)
        {
            iC_GatepassMasterService = _iC_GatepassMasterService;
            iC_GatePassAccountReviewService = _iC_GatePassAccountReviewService;
        }
        public async Task<RResult> Handle(GatepassMasterAccountsApprovalInfoUpdateCommand request, CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();
            rResult = await iC_GatePassAccountReviewService.GatePassAccountReviewSave(request.AccountsReview, cancellationToken);
            if (rResult.result == 1)
            {
                rResult = await iC_GatepassMasterService.GatepassMasterAccountsApprovalInfoUpdate(request.GatePassID, request.IsApproved, cancellationToken);
            }
            else
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
            }
            return rResult;
        }
    }
}
