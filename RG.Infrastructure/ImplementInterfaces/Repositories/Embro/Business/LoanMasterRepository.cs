using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Business.LoanMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.Application.ViewModel.Embro.Business.LoanMasters;
using RG.DBEntities.Embro.Business;
using RG.Infrastructure.Persistence.EmbroDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Business
{
    public class LoanMasterRepository : GenericRepository<LoanMaster>, ILoanMasterRepository
    {
        private readonly EmbroDBContext _dbCon;
        private readonly ICurrentUserService _currentUserService;
        public LoanMasterRepository(EmbroDBContext dbCon, ICurrentUserService currentUserService) : base(dbCon)
        {
            _dbCon = dbCon;
            _currentUserService = currentUserService;
        }

        //public async Task<LoanMaster> GetDataToUpdateLoanMaster( CancellationToken cancellationToken)
        //{
        //    var data = await _dbCon.LoanMaster
        //        //.Include(x => x.LoanInstallment.Where(y => y.IsActive == true && y.IsRemoved == false))
        //        .Where(x => x.IsActive == true && x.IsRemoved == false).FirstOrDefaultAsync(cancellationToken);
        //    return data;
        //}

        public IQueryable<LoanMasterGridDataRM> GetLoanMasterGridDataList(int BankID = 0, int LoanTypeID = 0, string PaymentType = null)
        {
            var query = from lm in _dbCon.LoanMaster
                        join lt in _dbCon.LoanType on lm.LoanTypeID equals lt.ID
                        join bn in _dbCon.CBM_Bank on lm.BankID equals bn.BankID
                        join com in _dbCon.CompanyInfo on bn.CompanyID equals com.CompanyID
                        join bc in _dbCon.Vw_BasicCOA on (int)lm.LoanCOAID  equals   bc.AccID 
                        join chargeQ in _dbCon.BasicCOA on lm.LoanChargeCOAID equals chargeQ.ID into _chargeQ
                        from chargeAcc in _chargeQ.DefaultIfEmpty()

                        where lm.IsRemoved == false && lm.IsActive == true && bc.CompanyId == _currentUserService.CompanyID
                        select new LoanMasterGridDataRM()
                        {
                            LoanID=lm.LoanID,
                            CompanyID = (int)com.CompanyID,
                            CompanyName = com.Companyname,
                            BankID= lm.BankID,
                            BankName=bn.BankName,
                            LoanTypeID = lm.LoanTypeID,
                            LoanType=lt.LoanTypeName,
                            PaymentType = lm.PaymentType,
                            LoanCOAID= lm.LoanCOAID,
                            LoanNumber=bc.AccName,
                            IsPrincipleCOA=lm.IsPrincipleCOA,
                            LoanChargeAccount=chargeAcc.DESCRIPTION.Trim(),
                            LoanChargeCOAID = lm.LoanChargeCOAID,
                            LoanLimitAmount =lm.LoanLimitAmount,
                            LoanAmount=lm.LoanAmount,
                            InterestPercent=lm.InterestPercent,
                            TotalInstallment=lm.TotalInstallment,
                            InstallmentAmount=lm.InstallmentAmount,
                            PaymentPeriodInMonth=lm.PaymentPeriodInMonth,
                            StartDate= lm.StartDate,
                            EndDate = lm.EndDate,
                        };
            if (!string.IsNullOrEmpty(PaymentType))
            {
                query = query.Where(w => w.PaymentType == PaymentType);
            }
            if (BankID > 0)
            {
                query = query.Where(w => w.BankID == BankID);
            }
            if (LoanTypeID > 0)
            {
                query = query.Where(w => w.LoanTypeID == LoanTypeID);
            }

            var aa = query.ToQueryString();
            return query;
        }

        public async Task<bool> IsDuplicateValue(LoanMasterCreateVM model)
        {
            var masterLoanDuplicate = new List<LoanMaster>();
            var interestLonDuplicate = new List<LoanMaster>();

            if (model.IsPrincipleCOA == true)
            {
                var _dataQuery = _dbCon.LoanMaster
                    .Where(x => x.IsActive == true && x.IsRemoved == false && x.LoanCOAID == model.LoanCOAID && x.IsPrincipleCOA == true);
                if (model.LoanID > 0)
                {
                    _dataQuery = _dataQuery.Where(b => b.LoanID != model.LoanID);
                }
                masterLoanDuplicate = await _dataQuery.ToListAsync();
            }
            if (model.IsPrincipleCOA == false)
            {
                var dataOtherQuery = _dbCon.LoanMaster
                    .Where(x => x.IsActive == true && x.IsRemoved == false && x.IsPrincipleCOA == false && x.LoanChargeCOAID == model.LoanChargeCOAID);

                if (model.LoanID > 0)
                {
                    dataOtherQuery = dataOtherQuery.Where(b => b.LoanID != model.LoanID);
                }
                interestLonDuplicate = await dataOtherQuery.ToListAsync();
            }

            if (masterLoanDuplicate.Count>0)
            {
                return true;
            }
            else if(interestLonDuplicate.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<RResult> LoanMasterUpdate(LoanMaster entity,CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();
            try
            {
                //var dbEntity = await _dbCon.LoanMaster
                //                    .Include(x => x.LoanInstallment.Where(x => x.IsActive == true && x.IsRemoved == false))
                //                    .Where(x => x.LoanID == entity.LoanID).FirstAsync(cancellationToken);

                #region LoanInstallment Delete
                //foreach (var dbLoanInstallmentItme in dbEntity.LoanInstallment)
                //{
                //    if (!entity.LoanInstallment.Any(x=>x.LoanInstallmentID==dbLoanInstallmentItme.LoanInstallmentID))
                //    {
                //        dbLoanInstallmentItme.IsRemoved = true;
                //        _dbCon.Update(dbLoanInstallmentItme);
                //    }
                //}
                #endregion

                #region LoanMaster Table Update
                var existingChildLonan = _dbCon.LoanMaster
                       .Where(x => x.LoanID == entity.LoanID).FirstOrDefault();
                if (existingChildLonan!=null)
                {

                    //existingChildLonan.IsRemoved = true;

                    existingChildLonan.LoanID = entity.LoanID;
                    existingChildLonan.PaymentType = entity.PaymentType;
                    existingChildLonan.StartDate = entity.StartDate;
                    existingChildLonan.EndDate = entity.EndDate;
                    existingChildLonan.LoanAmount = entity.LoanAmount;
                    existingChildLonan.InterestPercent = entity.InterestPercent;
                    existingChildLonan.TotalInstallment = entity.TotalInstallment;
                    existingChildLonan.PaymentPeriodInMonth = entity.PaymentPeriodInMonth;
                    existingChildLonan.BankID = entity.BankID;
                    existingChildLonan.LoanTypeID = entity.LoanTypeID;
                    existingChildLonan.LoanCOAID = entity.LoanCOAID;
                    existingChildLonan.LoanChargeCOAID = entity.LoanChargeCOAID;
                    existingChildLonan.LoanLimitAmount = entity.LoanLimitAmount;
                    existingChildLonan.InstallmentAmount = entity.InstallmentAmount;
                    _dbCon.Update(existingChildLonan);
                    await _dbCon.SaveChangesAsync(cancellationToken);
                    rResult.result = 1;
                    rResult.message = ReturnMessage.UpdateMessage;

                    //if (existingChildLonan.IsRemoved)
                    //{
                    //    existingChildLonan.LoanID = 0;
                    //    existingChildLonan.PaymentType = entity.PaymentType;
                    //    existingChildLonan.StartDate = entity.StartDate;
                    //    existingChildLonan.EndDate = entity.EndDate;
                    //    existingChildLonan.LoanAmount = entity.LoanAmount;
                    //    existingChildLonan.InterestPercent = entity.InterestPercent;
                    //    existingChildLonan.TotalInstallment = entity.TotalInstallment;
                    //    existingChildLonan.PaymentPeriodInMonth = entity.PaymentPeriodInMonth;
                    //    existingChildLonan.BankID = entity.BankID;
                    //    existingChildLonan.IsActive = true;
                    //    _dbCon.Add(existingChildLonan);
                    //}
                }
                //else
                //{
                //    existingChildLonan.StartDate = entity.StartDate;
                //    existingChildLonan.EndDate = entity.EndDate;
                //    existingChildLonan.LoanAmount = entity.LoanAmount;
                //    existingChildLonan.InterestPercent = entity.InterestPercent;
                //    existingChildLonan.TotalInstallment = entity.TotalInstallment;
                //    existingChildLonan.PaymentPeriodInMonth = entity.PaymentPeriodInMonth;
                //    existingChildLonan.BankID = entity.BankID;
                //    existingChildLonan.PaymentType = entity.PaymentType;
                //    _dbCon.Update(existingChildLonan);
                //}
                #endregion

                #region LoanInatallment Insert and Update
                //foreach (var updateLoanInstallmentItme in entity.LoanInstallment)
                //{
                //    try
                //    {
                //        var existingChild = dbEntity.LoanInstallment
                //       .Where(x => x.LoanInstallmentID == updateLoanInstallmentItme.LoanInstallmentID && updateLoanInstallmentItme.LoanInstallmentID>0).FirstOrDefault();
                //        if (existingChild != null)
                //        {
                //            existingChild.InstallmentNo = updateLoanInstallmentItme.InstallmentNo;
                //            existingChild.InstallmentDate = updateLoanInstallmentItme.InstallmentDate;
                //            existingChild.InstallmentAmount = updateLoanInstallmentItme.InstallmentAmount;
                //            existingChild.InterestAmount = updateLoanInstallmentItme.InterestAmount;
                //            _dbCon.Update(existingChild);
                //        }
                //        else
                //        {
                //            updateLoanInstallmentItme.LoanID = entity.LoanID;
                //            _dbCon.Add(updateLoanInstallmentItme);
                //        }
                //    }
                //    catch (Exception e)
                //    {

                //        throw new Exception(e.Message);
                //    }

                //}

                //await _dbCon.SaveChangesAsync(cancellationToken);
                //rResult.result = 1;
                //rResult.message = ReturnMessage.UpdateMessage;
                #endregion
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return rResult;
        }

     public async Task<BankLoanPositionRM> LoanDetailsReport(DateTime DateFrom, DateTime DateTo,int CompanyID, int BankID = 0, int LoanTypeID = 0, int LoanAccID = 0,int UserID=0)
        {
            var returnList = new BankLoanPositionRM();
            try
            {
                //if (UserID>0) {
                    await _dbCon.LoadStoredProc("rpt.USP_BankLoanPosition", commandTimeout: 900)
                                   .WithSqlParam("DateFrom", DateFrom)
                                   .WithSqlParam("DateTo", DateTo)
                                   .WithSqlParam("CompanyID", CompanyID)
                                   .WithSqlParam("BankID", BankID)
                                   .WithSqlParam("LoanTypeID", LoanTypeID)
                                   .WithSqlParam("LoanAccID", LoanAccID)
                                 .ExecuteStoredProcAsync((handler) =>
                                 {
                                     returnList.BankLoanPositionData = handler.ReadToList<BankLoanPositionData>() as List<BankLoanPositionData>;

                                 });
                    returnList.DateFrom = DateFrom.ToString("dd-MMM-yyyy");
                    returnList.DateTo = DateTo.ToString("dd-MMM-yyyy");
                //}               
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return returnList;
          
        }

        public async Task<List<SelectListItem>> DDLLoanAccounts(int bankID,int loanTypeID, string predict, CancellationToken cancellationToken = default)
        {
            var dataQuery = (from lm in _dbCon.LoanMaster
                              
                              join coa in _dbCon.BasicCOA on lm.LoanCOAID equals coa.ID
                              where lm.BankID == bankID && lm.LoanTypeID==loanTypeID && lm.IsPrincipleCOA == true
                              select new SelectListItem
                              {
                                  Text = coa.DESCRIPTION.Trim(),
                                  Value = coa.ID.ToString()
                              });
            if (predict!=null)
            {
                dataQuery = dataQuery.Where(x => x.Text.Contains(predict));
            }
            var data= await dataQuery.ToListAsync(cancellationToken);
          
            return data;
        }
    }
}
