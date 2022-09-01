using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.Embro.Business;
using RG.Application.ViewModel.Embro.Business.LoanMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Business.LoanMasters.Commands.Create
{
    public class LoanMasterCreateCommand:IRequest<RResult>
    {
        public LoanMasterCreateVM model { get; set; }
        //public bool result { get; set; }

    }
    public class LoanMasterCreateCommandHandler : IRequestHandler<LoanMasterCreateCommand, RResult>
    {
        private readonly ILoanMasterService _loanMasterService;

        public LoanMasterCreateCommandHandler(ILoanMasterService loanMasterService)
        {
            _loanMasterService = loanMasterService;
        }
        public async Task<RResult> Handle(LoanMasterCreateCommand request, CancellationToken cancellationToken)
        {

            //if (request.model.PaymentType == "Principal")
            //{
            //    request.result = true;

            //}
            //else
            //{
            //    request.result = false;
            //}
            return await _loanMasterService.Create(request.model,true);
        }
    }
}
