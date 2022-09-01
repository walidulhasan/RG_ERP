using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Embro.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Business.CBM_Cheque.Queries
{
    public class DDLSupplierWhomChequePaidToGetQuery : IRequest<List<SelectListItem>>
    {
        public int AccountID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Predict { get; set; }
    }
    public class DDLSupplierWhomChequePaidToGetQueryHandler : IRequestHandler<DDLSupplierWhomChequePaidToGetQuery, List<SelectListItem>>
    {
        private readonly ICBM_ChequeService _cBM_ChequeService;

        public DDLSupplierWhomChequePaidToGetQueryHandler(ICBM_ChequeService cBM_ChequeService)
        {
            _cBM_ChequeService = cBM_ChequeService;
        }
        public async Task<List<SelectListItem>> Handle(DDLSupplierWhomChequePaidToGetQuery request, CancellationToken cancellationToken)
        {
            return await _cBM_ChequeService.DDLSupplierWhomChequePaidTo(request.AccountID, request.FromDate, request.ToDate, request.Predict, cancellationToken);
        }
    }
}
