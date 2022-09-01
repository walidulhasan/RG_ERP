using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries;
using RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class VoucherShortInfoTBViewComponent : ViewComponent
    {
        private readonly IMediator mediator;
        public VoucherShortInfoTBViewComponent(IMediator _mediator)
        {
            mediator = _mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync(VoucherShortInfoTBVCQM queryModel)
        {
            var data = await mediator.Send(new GetVoucherShortInfoTBQuery { AccountID = queryModel.AccountId,DateFrom=queryModel.DateFrom,DateTo=queryModel.DateTo, NeedConversion = queryModel.NeedConversion });

            return View("VoucherShortInfoTBVC", data);
        }
    }
}
