using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.AOP.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AOP.Setup.Tbl_PaymentTypes.Queries
{
    public class GetDDLPaymentTypeQuery : IRequest<List<SelectListItem>>
    {
    }
    public class GetDDLPaymentTypeQueryHandler : IRequestHandler<GetDDLPaymentTypeQuery, List<SelectListItem>>
    {
        private readonly ITbl_PaymentTypeService tbl_PaymentTypeService;

        public GetDDLPaymentTypeQueryHandler(ITbl_PaymentTypeService _tbl_PaymentTypeService)
        {
            tbl_PaymentTypeService = _tbl_PaymentTypeService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLPaymentTypeQuery request, CancellationToken cancellationToken)
        {
            return await tbl_PaymentTypeService.DDLPaymentType();
        }
    }
}
