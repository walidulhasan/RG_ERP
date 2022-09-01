using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Business.LoanMasters.Queries.RequestResponseModel;
using RG.Application.ViewModel.Embro.Business.LoanMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Business
{
    public interface ILoanMasterService
    {
        Task<RResult> Create(LoanMasterCreateVM loanMasterCreateVM, bool saveChange = true);
        //Task<LoanMasterCreateVM> GetDataToUpdateLoanMaster(CancellationToken cancellationToken);
        Task<RResult> LoanMasterUpdate(LoanMasterCreateVM model, CancellationToken cancellationToken);
        Task<BankLoanPositionRM> LoanDetailsReport(DateTime DateFrom, DateTime DateTo, int CompanyID, int BankID = 0, int LoanTypeID = 0, int LoanAccID = 0, int UserID=0);
        public IQueryable<LoanMasterGridDataRM> GetLoanMasterGridDataList(int BankID = 0, int LoanTypeID = 0, string PaymentType = null);

        Task<RResult> RemoveLoanMaster(int loanID, bool saveChange);
        Task<List<SelectListItem>> DDLLoanAccounts(int bankID,int loanTypeID,string predict, CancellationToken cancellationToken = default);
    }
}
