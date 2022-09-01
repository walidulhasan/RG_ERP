using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedCheques.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.CBM_PrintedCheques.Commands.Update
{
    public class UpdateChequeStatusQuery : IRequest<RResult>
    {
        public List<UpdateChequeStatusDTM> SelectedData { get; set; }
    }
    public class UpdateChequeStatusQueryHandler : IRequestHandler<UpdateChequeStatusQuery, RResult>
    {
        private readonly ICBM_PrintedChequeService _cBM_PrintedChequeService;

        public UpdateChequeStatusQueryHandler(ICBM_PrintedChequeService cBM_PrintedChequeService)
        {
            _cBM_PrintedChequeService = cBM_PrintedChequeService;
        }
        public async Task<RResult> Handle(UpdateChequeStatusQuery request, CancellationToken cancellationToken)
        {
            return await _cBM_PrintedChequeService.UpdateChequeStatus(request.SelectedData,true);
        }
    }
}
