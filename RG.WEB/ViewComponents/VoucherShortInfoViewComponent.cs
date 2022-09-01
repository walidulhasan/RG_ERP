using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries;
using RG.Application.Contracts.Embro.AccountsReports.Vouchers.Queries.QueryResponseModel;
using System.Threading.Tasks;

namespace RG.WEB.ViewComponents
{
    public class VoucherShortInfoViewComponent : ViewComponent
    {
        private readonly IMediator mediator;        
        public VoucherShortInfoViewComponent(IMediator _mediator)
        {
            mediator = _mediator;           
        }
        public async Task<IViewComponentResult> InvokeAsync(VoucherShortInfoVCQM queryModel)
        {
            var data = await mediator.Send(new GetVoucherShortInfoQuery { AccountID = queryModel.AccountId,DateFrom=queryModel.DateFrom,DateTo=queryModel.DateTo,NeedConversion=queryModel.NeedConversion });

            return View("VoucherShortInfoVC", data);
        }
    }
}
