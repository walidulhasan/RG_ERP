using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatePassAccountReviews.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface IIC_GatePassAccountReviewService
    {
        Task<RResult> GatePassAccountReviewSave(IC_GatePassAccountReviewDTM model, CancellationToken cancellationToken);
    }
}
