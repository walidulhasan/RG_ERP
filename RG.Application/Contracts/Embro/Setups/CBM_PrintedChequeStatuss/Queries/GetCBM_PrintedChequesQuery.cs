using MediatR;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedChequeStatuss.Queries.QueryResponseModel;
using RG.Application.Interfaces.Services.Embro.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Setups.CBM_PrintedChequeStatuss.Queries
{
    public class GetCBM_PrintedChequesQuery:IRequest<List<CBM_PrintedChequesRM>>
    {
        public int AccountID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int StatusID { get; set; }
        public string PaidTo { get; set; }
    }
    public class GetCBM_PrintedChequesQueryandler : IRequestHandler<GetCBM_PrintedChequesQuery, List<CBM_PrintedChequesRM>>
    {
        private readonly ICBM_PrintedChequeStatusService _cBM_PrintedChequeStatusService;

        public GetCBM_PrintedChequesQueryandler(ICBM_PrintedChequeStatusService cBM_PrintedChequeStatusService)
        {
            _cBM_PrintedChequeStatusService = cBM_PrintedChequeStatusService;
        }
        public async Task<List<CBM_PrintedChequesRM>> Handle(GetCBM_PrintedChequesQuery request, CancellationToken cancellationToken)
        {
            return await _cBM_PrintedChequeStatusService.GetCBM_PrintedCheques(request.AccountID, request.FromDate, request.ToDate,request.StatusID,request.PaidTo);
        }
    }
}
