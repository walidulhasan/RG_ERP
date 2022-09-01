using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Business.LoanMasters.Queries.RequestResponseModel;
using RG.Application.ViewModel.Embro.Business.LoanMasters;
using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Business
{
    public interface ILoanMasterRepository : IGenericRepository<LoanMaster>
    {
        //Task<LoanMaster> GetDataToUpdateLoanMaster(CancellationToken cancellationToken);

        Task<RResult> LoanMasterUpdate(LoanMaster entity, CancellationToken cancellationToken);

        Task<BankLoanPositionRM> LoanDetailsReport(DateTime DateFrom, DateTime DateTo, int CompanyID, int BankID = 0, int LoanTypeID = 0, int LoanAccID = 0, int UserID=0);
        public IQueryable<LoanMasterGridDataRM> GetLoanMasterGridDataList(int BankID = 0, int LoanTypeID = 0, string PaymentType = null);

        Task<bool> IsDuplicateValue(LoanMasterCreateVM model);
        Task<List<SelectListItem>> DDLLoanAccounts(int bankID,int loanTypeID,string predict, CancellationToken cancellationToken = default);
    }
}
