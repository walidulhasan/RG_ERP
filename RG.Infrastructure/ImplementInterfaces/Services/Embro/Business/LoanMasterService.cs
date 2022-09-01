using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Business.LoanMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.Application.Interfaces.Services.Embro.Business;
using RG.Application.ViewModel.Embro.Business.LoanMasters;
using RG.DBEntities.Embro.Business;
using RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Embro.Business
{
    public class LoanMasterService : ILoanMasterService
    {
        private readonly ILoanMasterRepository _loanMasterRepository;
        private readonly ILoanInstallmentRepository _loanInstallmentRepository;
        private readonly IMapper _mapper;

        public LoanMasterService(ILoanMasterRepository loanMasterRepository, ILoanInstallmentRepository loanInstallmentRepository, IMapper mapper)
        {
            _loanMasterRepository = loanMasterRepository;
            _loanInstallmentRepository = loanInstallmentRepository;
            _mapper = mapper;
        }
        public async Task<RResult> Create(LoanMasterCreateVM loanMasterCreateVM ,bool saveChange = true)
        {
            try
            {
                RResult result = new();
                var entity = _mapper.Map<LoanMasterCreateVM, LoanMaster>(loanMasterCreateVM);
                entity.IsActive = true;
                var IsDuplicate = await _loanMasterRepository.IsDuplicateValue(loanMasterCreateVM);
                if (IsDuplicate)
                {
                    result.result = 0;
                    result.message = ReturnMessage.DuplicateMessage;
                }
                else
                {
                    //entity.LoanInstallment.ForEach(x=> { x.IsActive = true; });
                    var obj = await _loanMasterRepository.InsertAsync(entity, saveChange);
                    if (obj != null)
                    {
                        result.result = 1;
                        result.message = ReturnMessage.InsertMessage;
                    }
                    else
                    {
                        result.result = 0;
                        result.message = ReturnMessage.ErrorMessage;
                    }
                    return result;
                }
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IQueryable<LoanMasterGridDataRM> GetLoanMasterGridDataList(int BankID = 0, int LoanTypeID = 0,string PaymentType=null)
        {
            return _loanMasterRepository.GetLoanMasterGridDataList(BankID,LoanTypeID,PaymentType);
        }

        //public async Task<LoanMasterCreateVM> GetDataToUpdateLoanMaster(CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var entity = await _loanMasterRepository.GetDataToUpdateLoanMaster(cancellationToken);
        //        var model=_mapper.Map<LoanMaster,LoanMasterCreateVM>(entity);
        //        //model.LoanInstallment =await _loanInstallmentRepository.LoanInstallmentEdit(id, cancellationToken);
        //        return model;
        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }
        //}

        public async Task<RResult> LoanMasterUpdate(LoanMasterCreateVM model, CancellationToken cancellationToken)
        {
            try
            {
                RResult result = new();
                var IsDuplicate = await _loanMasterRepository.IsDuplicateValue(model);
                if (IsDuplicate)
                {
                    result.result = 0;
                    result.message = ReturnMessage.DuplicateMessage;
                }
                else
                {
                    var entity = _mapper.Map<LoanMasterCreateVM, LoanMaster>(model);
                    return await _loanMasterRepository.LoanMasterUpdate(entity, cancellationToken);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
           
           
        }

        public async Task<RResult> RemoveLoanMaster(int loanID, bool saveChange)
        {
            RResult result = new RResult();
            var entity = await _loanMasterRepository.GetByIdAsync(loanID);
            entity.IsRemoved = true;
            await _loanMasterRepository.UpdateAsync(entity, entity.LoanID, saveChange);
            result.result = 1;
            result.message = ReturnMessage.DeleteMessage;
            return result;
        }

        public async Task<BankLoanPositionRM> LoanDetailsReport(DateTime DateFrom, DateTime DateTo, int CompanyID, int BankID = 0, int LoanTypeID = 0, int LoanAccID = 0, int UserID=0)
        {
            return await _loanMasterRepository.LoanDetailsReport(DateFrom, DateTo, CompanyID, BankID, LoanTypeID, LoanAccID,UserID);
        }

        public async Task<List<SelectListItem>> DDLLoanAccounts(int bankID,int loanTypeID, string predict, CancellationToken cancellationToken = default)
        {
            return await _loanMasterRepository.DDLLoanAccounts(bankID, loanTypeID,predict, cancellationToken);
        }
    }
}
