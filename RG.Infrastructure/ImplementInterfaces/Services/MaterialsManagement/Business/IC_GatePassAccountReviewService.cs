using AutoMapper;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatePassAccountReviews.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class IC_GatePassAccountReviewService : IIC_GatePassAccountReviewService
    {
        private readonly IIC_GatePassAccountReviewRepository iC_GatePassAccountReviewRepository;
        private readonly IMapper mapper;

        public IC_GatePassAccountReviewService(IIC_GatePassAccountReviewRepository _iC_GatePassAccountReviewRepository, IMapper _mapper)
        {
            iC_GatePassAccountReviewRepository = _iC_GatePassAccountReviewRepository;
            mapper = _mapper;
        }
        public async Task<RResult> GatePassAccountReviewSave(IC_GatePassAccountReviewDTM model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<IC_GatePassAccountReviewDTM, IC_GatePassAccountReview>(model);
            return await iC_GatePassAccountReviewRepository.GatePassAccountReviewSave(entity, cancellationToken);
        }
    }
}
