using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Commands.DataTransferModel;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AOP.Business;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Repositories.UserAuthGBS.Setup;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class IC_GatepassMasterService : IIC_GatepassMasterService
    {
        private readonly IIC_GatepassMasterRepository iC_GatepassMasterRepository;
        private readonly ICurrentUserService currentUserService;
        private readonly IMapper mapper;
        private readonly IUserEmployeeRepository _userEmployeeRepository;
        private readonly ITbl_Issuance_MasterRepository _tbl_Issuance_MasterRepository;

        public IC_GatepassMasterService(IIC_GatepassMasterRepository _iC_GatepassMasterRepository, ICurrentUserService _currentUserService
            , IMapper _mapper, IUserEmployeeRepository userEmployeeRepository, ITbl_Issuance_MasterRepository tbl_Issuance_MasterRepository)
        {
            iC_GatepassMasterRepository = _iC_GatepassMasterRepository;
            currentUserService = _currentUserService;
            mapper = _mapper;
            _userEmployeeRepository = userEmployeeRepository;
            _tbl_Issuance_MasterRepository = tbl_Issuance_MasterRepository;
        }

        public async Task<RResult> ApprovedGatePass(long gatePassID, CancellationToken cancellationToken)
        {
            var userID = currentUserService.AlgoUserID;
            return await iC_GatepassMasterRepository.ApprovedGatePass(gatePassID, userID, cancellationToken);
        }

        public async Task<RResult> GatepassMasterAccountsApprovalInfoUpdate(long gatePassMasterID, bool isApproved, CancellationToken cancellationToken)
        {
            var entity = await iC_GatepassMasterRepository.GetByIdAsync(gatePassMasterID);
            entity.IsApprovedByAccounts = isApproved;
            entity.AccountsApprovalDate = DateTime.Now;
            entity.AccountsApprovedBy = currentUserService.UserID;
            return await iC_GatepassMasterRepository.UpdateGatepassMaster(entity, cancellationToken);
        }

        public async Task<List<ExportSalesItemVM>> GetExportSalesItem(long GatePassID, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterRepository.GetExportSalesItem(GatePassID, cancellationToken);
        }

        public async Task<List<GatePassAccountIssueRM>> GetGatePassAccountIssueList(GatePassAccountIssueQM reqModel, CancellationToken cancellationToken)
        {
            var users = await _userEmployeeRepository.GetUserEmployee().ToListAsync();
            var data = await iC_GatepassMasterRepository.GetGatePassAccountIssueList(reqModel, cancellationToken);
            foreach (var item in data)
            {
                var user = users.Where(x => x.UserID == item.CA_UserID).FirstOrDefault();
                if (user != null)
                {
                    item.CreatedEmployee = user.EmployeeName;
                    item.CreatedEmployeeDept = user.DepartmentName;
                    item.CreatedEmployeeDesig = user.DesignationName;
                }
            }
            return data;
        }

        public async Task<List<GatepassRM>> GetGatePassApprovalList(GatepassQM model, CancellationToken cancellationToken)
        {
            var users = await _userEmployeeRepository.GetUserEmployee().ToListAsync();

            var data= await iC_GatepassMasterRepository.GetGatePassApprovalList(model, cancellationToken);
            foreach (var item in data)
            {
                var user = users.Where(x => x.UserID == item.CA_UserID).FirstOrDefault();
                if (user != null)
                {
                    item.CreatedEmployee = user.EmployeeName;
                    item.CreatedEmployeeDept = user.DepartmentName;
                    item.CreatedEmployeeDesig = user.DesignationName;
                }
            }
            return data;
        }

        public async Task<List<GatepassRM>> GetGatePassMarkOutList(GatepassQM model, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterRepository.GetGatePassMarkOutList(model, cancellationToken);
        }

        public async Task<List<GatepassRM>> GetGatePassReceivableList(GatepassQM model, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterRepository.GetGatePassReceivableList(model, cancellationToken);
        }

        public async Task<string> GetGatePassSerial(byte categoryID)
        {
            return await iC_GatepassMasterRepository.GetGatePassSerial(categoryID);
        }

        public IQueryable<GatepassRM> GetICBrowseGetPassesList(GatepassQM model)
        {

            var gatePassQuery = iC_GatepassMasterRepository.GetICBrowseGetPassesList(model);

            return gatePassQuery;
        }

        public async Task<IC_GatepassMasterRM> GetIC_GatepassMasterDetailInfoByID(long gatePassID, CancellationToken cancellationToken)
        {
            var rtnData = await iC_GatepassMasterRepository.GetIC_GatepassMasterDetailInfoByID(gatePassID, cancellationToken);
            var data = mapper.Map<IC_GatepassMaster, IC_GatepassMasterRM>(rtnData);
            return data;
        }

        public async Task<List<LocalSalesItemVM>> GetLocalSalesItem(long GatePassID, CancellationToken cancellationToken)
        {
            var data= await iC_GatepassMasterRepository.GetLocalSalesItem(GatePassID, cancellationToken);
            foreach (var item in data)
            {
                if (item.ProcessId != 6)
                {
                    item.PMDescription = (await _tbl_Issuance_MasterRepository.GetIssuancePaymentInfo(item.IssuanceDetailID.Value)).PaymentMode;
                }
            }
            return data;
        }

        public async Task<List<ReturnableItemVM>> GetReturnableItem(long GatePassID, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterRepository.GetReturnableItem(GatePassID, cancellationToken);
        }

        public async Task<bool> IsApprovedGatePass(long gatePassID, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterRepository.IsApprovedGatePass(gatePassID, cancellationToken);
        }

        public async Task<RResult> MarkedOutGatePass(long gatePassID, int userID, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterRepository.MarkedOutGatePass(gatePassID, userID, cancellationToken);
        }

        public async Task<RResult> RemoveGatepass(long gatePassID, bool isSuperAdmin, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterRepository.RemoveGatepass(gatePassID,isSuperAdmin, cancellationToken);
        }

        public async Task<RResult> RemoveIC_GatepassMaster(long id, CancellationToken cancellationToken)
        {
            var mEntity = await iC_GatepassMasterRepository.GetByIdAsync(id);
            mEntity.isDeleted = true;
            mEntity.DeletedBy = currentUserService.UserID;
            mEntity.DeletedOn = DateTime.Now;
            mEntity.IsRemoved = true;
            return await iC_GatepassMasterRepository.UpdateGatepassMaster(mEntity, cancellationToken);
        }

        public async Task<RResult> SaveExportSalses(ExportSalesGatePassDTM model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<ExportSalesGatePassDTM, IC_GatepassMaster>(model);
            entity = await AddDefaultPropertiesToGatepassMaster(entity);
            entity.IC_ExportSalesGatePassMaster.IssuedBy = currentUserService.AlgoUserID;
            return await iC_GatepassMasterRepository.SaveGatepassMaster(entity, cancellationToken);
        }

        public async Task<RResult> SaveLocalSales(LocalSalesGatePassDTM model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<LocalSalesGatePassDTM, IC_GatepassMaster>(model);
            entity = await AddDefaultPropertiesToGatepassMaster(entity);
            entity.IC_LocalSalesGatePassMaster.IssuedBy = currentUserService.AlgoUserID;
            return await iC_GatepassMasterRepository.SaveGatepassMaster(entity, cancellationToken);
        }

        public async Task<RResult> SaveNonReturnable(NonReturnableGatePassDTM model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<NonReturnableGatePassDTM, IC_GatepassMaster>(model);
            entity = await AddDefaultPropertiesToGatepassMaster(entity);
            entity.IC_NonReturnableGatePassMaster.IssuedBy = currentUserService.AlgoUserID;
            return await iC_GatepassMasterRepository.SaveGatepassMaster(entity, cancellationToken);
        }

        public async Task<RResult> SaveReturnableGatePass(ReturnableGatePassDTM model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<ReturnableGatePassDTM, IC_GatepassMaster>(model);
            entity = await AddDefaultPropertiesToGatepassMaster(entity);
            entity.IC_ReturnableGatePassMaster.IssuedBy = currentUserService.AlgoUserID;
            return await iC_GatepassMasterRepository.SaveGatepassMaster(entity, cancellationToken);
        }

        public async Task<RResult> SaveSampleGatePass(SampleGatePassDTM model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<SampleGatePassDTM, IC_GatepassMaster>(model);
            entity = await AddDefaultPropertiesToGatepassMaster(entity);
            entity.IC_SampleGatePassMaster.IssuedBy = currentUserService.AlgoUserID;
            return await iC_GatepassMasterRepository.SaveGatepassMaster(entity, cancellationToken);
        }

        public async Task<RResult> SaveScrapSales(ScrapSalesGatePassDTM model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<ScrapSalesGatePassDTM, IC_GatepassMaster>(model);
            entity = await AddDefaultPropertiesToGatepassMaster(entity);
            entity.IC_ScrapSalesGatePassMaster.PaymentMode = PaymentModes.PaymentModeCash;
            entity.IC_ScrapSalesGatePassMaster.IC_ScrapSalesGatePassDetail.ForEach(x => { x.PaymentMode = PaymentModes.PaymentModeCash; });
            entity.IC_ScrapSalesGatePassMaster.IssuedBy = currentUserService.AlgoUserID;
            return await iC_GatepassMasterRepository.SaveGatepassMaster(entity, cancellationToken);
        }

        public async Task<RResult> UpdateGatepassMasterDetail(IC_GatepassMaster entity, CancellationToken cancellationToken)
        {
            return await iC_GatepassMasterRepository.UpdateGatepassMasterDetail(entity, cancellationToken);
        }

        private async Task<IC_GatepassMaster> AddDefaultPropertiesToGatepassMaster(IC_GatepassMaster entity)
        {
            entity.Serial = await GetGatePassSerial(entity.CategoryID.Value);
            entity.DateTimeStamp = DateTime.Now;
            entity.isApproved = false;
            entity.isDeleted = false;
            entity.isMarkedOut = false;
            entity.CompanyID = currentUserService.CompanyID;
            entity.SEQ = null;
            return entity;
        }
    }
}
