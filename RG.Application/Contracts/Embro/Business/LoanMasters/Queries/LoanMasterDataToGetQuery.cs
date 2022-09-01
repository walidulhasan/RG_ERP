using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Interfaces.Services.Embro.Business;
using RG.Application.ViewModel.Embro.Business.LoanMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.Business.LoanMasters.Queries
{
    public class LoanMasterDataToGetQuery : IRequest<LoadResult>
    {
        public DataSourceLoadOptions LoadOptions { get; set; }
        public int BankID { get; set; } = 0;
        public int LoanTypeID { get; set; } = 0;
        public string PaymentType { get; set; } = null;
    }
    public class LoanMasterDataToGetQueryHandler : IRequestHandler<LoanMasterDataToGetQuery, LoadResult>
    {
        private readonly ILoanMasterService _loanMasterService;

        public LoanMasterDataToGetQueryHandler(ILoanMasterService loanMasterService)
        {
            _loanMasterService = loanMasterService;
        }
       
        public async Task<LoadResult>Handle(LoanMasterDataToGetQuery request, CancellationToken cancellationToken=default)
        {
            request.LoadOptions.PrimaryKey = new[] { "LoanID" };
            request.LoadOptions.PaginateViaPrimaryKey = true;
            var dataQuery = _loanMasterService.GetLoanMasterGridDataList(request.BankID,request.LoanTypeID,request.PaymentType);
            var date = await dataQuery.ToListAsync();
            var finalData = await DataSourceLoader.LoadAsync(dataQuery, request.LoadOptions, cancellationToken);
            return finalData;
        }
    }
}
