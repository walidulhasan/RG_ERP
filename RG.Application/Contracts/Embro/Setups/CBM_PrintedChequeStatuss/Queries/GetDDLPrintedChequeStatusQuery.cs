using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.CBM_PrintedChequeStatuss.Queries
{
    public class GetDDLPrintedChequeStatusQuery:IRequest<List<SelectListItem>>
    {

    }
    public class GetDDLPrintedChequeStatusQueryHandler : IRequestHandler<GetDDLPrintedChequeStatusQuery, List<SelectListItem>>
    {
        private readonly ICBM_PrintedChequeStatusService _cBM_PrintedChequeStatusService;

        public GetDDLPrintedChequeStatusQueryHandler(ICBM_PrintedChequeStatusService cBM_PrintedChequeStatusService)
        {
            _cBM_PrintedChequeStatusService = cBM_PrintedChequeStatusService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLPrintedChequeStatusQuery request, CancellationToken cancellationToken)
        {
            return await _cBM_PrintedChequeStatusService.DDLPrintedChequeStatus(cancellationToken);

        }
    }
}
