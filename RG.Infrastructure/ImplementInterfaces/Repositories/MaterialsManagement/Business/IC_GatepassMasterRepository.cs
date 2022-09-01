using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.MaterialsManagement.Business.IC_GatepassMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using RG.DBEntities.MaterialsManagement.Business;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class IC_GatepassMasterRepository : GenericRepository<IC_GatepassMaster>, IIC_GatepassMasterRepository
    {
        private readonly MaterialsManagementDBContext dbCon;
        private readonly ICurrentUserService _currentUserService;

        public IC_GatepassMasterRepository(MaterialsManagementDBContext _dbCon, ICurrentUserService currentUserService) : base(_dbCon)
        {
            dbCon = _dbCon;
            _currentUserService = currentUserService;
        }
        public async Task<RResult> ApprovedGatePass(long gatePassID, int userID, CancellationToken cancellationToken)
        {
            var rResult = new RResult();
            var gatePassEntity = await GetByIdAsync(gatePassID);
            gatePassEntity.ApprovedBy = userID;
            gatePassEntity.ApprovedID = _currentUserService.UserID;
            gatePassEntity.ApprovedOn = DateTime.Now;
            gatePassEntity.isApproved = true;
            dbCon.IC_GatepassMaster.Update(gatePassEntity);
            await dbCon.SaveChangesAsync(cancellationToken);
            rResult.result = 1;
            rResult.message = ReturnMessage.ApprovedMessage;
            return rResult;
        }

        public async Task<List<GatePassAccountIssueRM>> GetGatePassAccountIssueList(GatePassAccountIssueQM reqModel, CancellationToken cancellationToken)
        {
            var data = new List<GatePassAccountIssueRM>();

            if (reqModel.CategoryID == 0 || reqModel.Category == IC_DocumentCategoriesCC.LocalSales)
            {
                data.AddRange(await GetLocalSalesGatePassAccountIssueList(reqModel, cancellationToken));
            }
            if (reqModel.CategoryID == 0 || reqModel.Category == IC_DocumentCategoriesCC.ScrapSales)
            {
                data.AddRange(await GetScrapGatePassAccountIssueList(reqModel, cancellationToken));
            }

            return data;
        }

        public async Task<List<GatepassRM>> GetGatePassApprovalList(GatepassQM model, CancellationToken cancellationToken)
        {
            var data = await dbCon.vw_GetAllGatePass.Where(x => (model.CategoryID == 0 || x.CategoryID == model.CategoryID)
            && (x.IsAccountsApprovalRequired == false || (x.IsAccountsApprovalRequired == true && x.IsApprovedByAccounts == true))
            && x.isDeleted == false && x.isApproved == model.IsApproved
            && x.CreationDateTime.Value.Date >= model.StartDate && x.CreationDateTime.Value.Date <= model.EndDate)
                .Select(x => new GatepassRM
                {
                    CategoryID = x.CategoryID,
                    GatePassID = x.GatePassID,
                    CategoryName = x.CategoryName,
                    Serial = x.Serial,
                    Date = x.CreationDate,
                    Time = x.CreationDateTime.Value.ToString("h:mm tt"),
                    DepartmentName = x.DepartmentName,
                    isApproved = x.isApproved.Value,
                    CA_UserID = x.CA_UserID
                }).ToListAsync(cancellationToken);

            return data;
        }

        public async Task<List<GatepassRM>> GetGatePassMarkOutList(GatepassQM model, CancellationToken cancellationToken)
        {
            var data = await dbCon.vw_GetAllGatePass.Where(x => ((x.IsAccountsApprovalRequired == true && x.IsApprovedByAccounts == true) || (x.IsAccountsApprovalRequired == false))
             && x.isApproved == true
             && x.isDeleted == false && x.isMarkedOut == model.IsApproved
              && x.CreationDateTime.Value.Date >= model.StartDate && x.CreationDateTime.Value.Date <= model.EndDate)
                  .Select(x => new GatepassRM
                  {
                      CategoryID = x.CategoryID,
                      GatePassID = x.GatePassID,
                      CategoryName = x.CategoryName,
                      Serial = x.Serial,
                      Date = x.CreationDate,
                      Time = x.CreationDateTime.Value.ToString("h:mm tt"),
                      DepartmentName = x.DepartmentName,
                      isApproved = x.isApproved.Value
                  }).ToListAsync(cancellationToken);

            return data;
        }

        public async Task<List<GatepassRM>> GetGatePassReceivableList(GatepassQM model, CancellationToken cancellationToken)
        {
            var data = await dbCon.vw_GetAllGatePass.Where(x => x.isMarkedOut.Value == true && x.isDeleted == false && x.IsSatisfied == model.IsApproved && x.CategoryID == model.CategoryID
             && x.CreationDateTime.Value.Date >= model.StartDate && x.CreationDateTime.Value.Date <= model.EndDate)
                 .Select(x => new GatepassRM
                 {
                     CategoryID = x.CategoryID,
                     GatePassID = x.GatePassID,
                     CategoryName = x.CategoryName,
                     Serial = x.Serial,
                     Date = x.CreationDate,
                     Time = x.CreationDateTime.Value.ToString("h:mm tt"),
                     DepartmentName = x.DepartmentName,
                     isApproved = x.isApproved.Value,
                     IsSatisfied = x.IsSatisfied
                 }).ToListAsync(cancellationToken);

            return data;
        }

        public async Task<string> GetGatePassSerial(byte categoryID)
        {
            var data = await dbCon.IC_GatepassMaster
                .Where(x => x.CategoryID == categoryID && x.DateTimeStamp.Value.Year == DateTime.Now.Year && x.DateTimeStamp.Value.Month == DateTime.Now.Month)
                .Select(s => s.ID)
                .ToListAsync();
            var newSerial = (data.Count + 1).ToString();
            var month = DateTime.Now.ToString("MMM").ToUpper();
            return $"GP-{categoryID}{DateTime.Now:yy}{month}-{newSerial.PadLeft(4, '0')}";
        }

        public IQueryable<GatepassRM> GetICBrowseGetPassesList(GatepassQM model)
        {
            IQueryable<GatepassRM> gatePassData;
            try
            {
                var viewAllGatePass = _currentUserService.HasClaimAccess("ViewAllGatePass");
                var dataQuery = dbCon.vw_GetAllGatePass.Where(b => b.isDeleted == null || b.isDeleted == false);

                #region DateDucation
                if (model.StartDate.HasValue)
                {
                    dataQuery = dataQuery.Where(b => b.CreationDateTime.HasValue == true && b.CreationDateTime.Value.Date >= model.StartDate.Value.Date);
                }

                if (model.EndDate.HasValue)
                {
                    dataQuery = dataQuery.Where(b => b.CreationDateTime.HasValue == true && b.CreationDateTime.Value.Date <= model.EndDate.Value.Date);
                }
                #endregion DateDucation
                if (model.CategoryID > 0)
                {
                    dataQuery = dataQuery.Where(b => b.CategoryID == model.CategoryID);
                }
                if (!string.IsNullOrWhiteSpace(model.GatePassNo))
                {
                    dataQuery = dataQuery.Where(b => b.Serial == model.GatePassNo);
                }
                if (!viewAllGatePass && model.CA_UserId > 0)
                {
                    dataQuery = dataQuery.Where(b => b.CA_UserID == model.CA_UserId);
                }
                //if (!viewAllGatePass && model.CA_UserId > 0)
                //{
                //    dataQuery = dataQuery.Where(b => b.CA_UserID == model.CA_UserId);
                //}
                if (model.IsApproved.HasValue)
                {
                    dataQuery = dataQuery.Where(b => b.isApproved == model.IsApproved);
                }
                if (model.ApprovedById > 0)
                {
                    dataQuery = dataQuery.Where(b => b.ApprovedBy == model.ApprovedById);
                }
                if (model.IsAccountsApprovalRequired.HasValue)
                {
                    dataQuery = dataQuery.Where(b => b.IsAccountsApprovalRequired == model.IsAccountsApprovalRequired);
                }
                if (model.isAccountApprove.HasValue)
                {
                    dataQuery = dataQuery.Where(b => b.IsApprovedByAccounts == model.isAccountApprove);
                }
                if (model.IsMarkedOut.HasValue)
                {
                    dataQuery = dataQuery.Where(b => b.isMarkedOut == model.IsMarkedOut);
                }
                if (model.MarkedOutById.HasValue)
                {
                    dataQuery = dataQuery.Where(b => b.MarkedOutBy == model.MarkedOutById);
                }
                if (model.IsExpired.HasValue)
                {
                    dataQuery = dataQuery.Where(b => b.IsExpired == model.IsExpired);
                }
                if (model.Status.Length > 0)
                {
                    if (model.Status != "All")
                    {
                        dataQuery = dataQuery.Where(b => b.Status == model.Status);
                    }

                }

                gatePassData = dataQuery.Select(s => new GatepassRM
                {
                    ApprovedBy = s.ApprovalEmp,
                    ApprovedByID = s.ApprovedBy,
                    ApprovedDate = s.ApprovedDate,
                    ApprovedOn = s.ApprovedDateTime,
                    ApprovedTime = s.ApprovedTime,
                    CategoryID = s.CategoryID,
                    CategoryName = s.CategoryName,
                    CatName = s.CategoryName,
                    CreateDate = s.CreationDateTime,
                    CustomerName = s.CustomerName,
                    Date = s.CreationDate,
                    IsApprovedByAccounts = s.IsApprovedByAccounts == true ? true : false,
                    isApproved = s.isApproved == true ? true : false,
                    IsSatisfied = s.IsSatisfied,
                    DepartmentID = s.DepartmentID,
                    DepartmentName = s.DepartmentName,
                    GatePassID = s.GatePassID,
                    IsDeleted = s.isDeleted,
                    IsExpired = s.IsExpired.HasValue && s.IsExpired == 0 ? "No" : "Yes",
                    ExpireDayes = s.ExpireDayes,
                    IssuedBy = s.IssuerEmp,
                    IssuedById = s.IssuedBy,
                    MarkedOutBy = s.MarkOutEMP,
                    MarkedOutByID = s.MarkedOutBy,
                    MarkedOutOn = s.MarkOutDateTime,
                    Serial = s.Serial,
                    Status = s.Status,
                    Time = s.CreationTime,
                    VehicleNo = s.VehicleNo,
                    CA_UserID = s.CA_UserID,
                    IsAccountsApprovalRequired = s.IsAccountsApprovalRequired.Value
                }).OrderByDescending(o => o.Date);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return gatePassData;
        }

        public async Task<IC_GatepassMaster> GetIC_GatepassMasterDetailInfoByID(long gatePassID, CancellationToken cancellationToken)
        {
            try
            {
                var query = dbCon.IC_GatepassMaster
                         .Where(x => x.ID == gatePassID && x.IsActive == true && x.IsRemoved == false && (x.isDeleted == null || x.isDeleted == false))
                        .Include(lc => lc.IC_SampleGatePassMaster)
                        .ThenInclude(lcd => lcd.IC_SampleGatePassDetail.Where(x => x.IsActive == true && x.IsRemoved == false))

                        .Include(lc => lc.IC_LocalSalesGatePassMaster)
                        .ThenInclude(lcd => lcd.IC_LocalSalesGatePassDetail.Where(x => x.IsActive == true && x.IsRemoved == false))

                        .Include(lc => lc.IC_NonReturnableGatePassMaster)
                        .ThenInclude(lcd => lcd.IC_NonReturnableGatePassDetail.Where(x => x.IsActive == true && x.IsRemoved == false))

                        .Include(lc => lc.IC_ReturnableGatePassMaster)
                        .ThenInclude(lcd => lcd.IC_ReturnableGatePassDetail.Where(x => x.IsActive == true && x.IsRemoved == false))

                        .Include(em => em.IC_ExportSalesGatePassMaster)
                        .ThenInclude(emd => emd.IC_ExportSalesGatePassDetail.Where(x => x.IsActive == true && x.IsRemoved == false))

                        .Include(lc => lc.IC_ScrapSalesGatePassMaster)
                        .ThenInclude(lcd => lcd.IC_ScrapSalesGatePassDetail.Where(x => x.IsActive == true && x.IsRemoved == false))
                        ;
                var aa = query.ToQueryString();

                return await query.FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RResult> MarkedOutGatePass(long gatePassID, int userID, CancellationToken cancellationToken)
        {
            var rResult = new RResult();
            var gatePassEntity = await GetByIdAsync(gatePassID, cancellationToken);
            gatePassEntity.MarkedOutBy = userID;
            gatePassEntity.MarkedOutID = _currentUserService.UserID;
            gatePassEntity.MarkedOutOn = DateTime.Now;
            gatePassEntity.isMarkedOut = true;
            await dbCon.SaveChangesAsync(cancellationToken);
            rResult.result = 1;
            rResult.message = ReturnMessage.ApprovedMessage;
            return rResult;
        }

        public async Task<RResult> RemoveGatepass(long gatePassID, bool isSuperAdmin, CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();

            var dbEntity = await GetIC_GatepassMasterDetailInfoByID(gatePassID, cancellationToken);
            if (!isSuperAdmin && (dbEntity.IsApprovedByAccounts == true || dbEntity.isApproved == true))
            {
                rResult.result = 0;
                rResult.message = "Failed to remove, data already approved";
            }
            else
            {
                dbEntity.IsRemoved = true;
                dbEntity.isDeleted = true;
                dbEntity.DeletedBy = _currentUserService.UserID;
                dbEntity.DeletedOn = DateTime.Now;

                if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.SampleGmts)
                {
                    dbEntity.IC_SampleGatePassMaster.IsRemoved = true;
                    dbEntity.IC_SampleGatePassMaster.IC_SampleGatePassDetail.ForEach(x => { x.IsRemoved = true; });
                }
                else if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.LocalSales)
                {
                    dbEntity.IC_LocalSalesGatePassMaster.IsRemoved = true;
                    dbEntity.IC_LocalSalesGatePassMaster.IC_LocalSalesGatePassDetail.ForEach(x => { x.IsRemoved = true; });
                }
                else if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.NonReturnable)
                {
                    dbEntity.IC_NonReturnableGatePassMaster.IsRemoved = true;
                    dbEntity.IC_NonReturnableGatePassMaster.IC_NonReturnableGatePassDetail.ForEach(x => { x.IsRemoved = true; });
                }
                else if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.Returnable)
                {
                    dbEntity.IC_ReturnableGatePassMaster.IsRemoved = true;
                    dbEntity.IC_ReturnableGatePassMaster.IC_ReturnableGatePassDetail.ForEach(x => { x.IsRemoved = true; });
                }
                else if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.ExportSales)
                {
                    dbEntity.IC_ExportSalesGatePassMaster.IsRemoved = true;
                    dbEntity.IC_ExportSalesGatePassMaster.IC_ExportSalesGatePassDetail.ForEach(x => { x.IsRemoved = true; });
                }
                else if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.ScrapSales)
                {
                    dbEntity.IC_ScrapSalesGatePassMaster.IsRemoved = true;
                    dbEntity.IC_ScrapSalesGatePassMaster.IC_ScrapSalesGatePassDetail.ForEach(x => { x.IsRemoved = true; });
                }
                else
                {

                }

                await dbCon.SaveChangesAsync(cancellationToken);
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
            }
            return rResult;
        }

        public async Task<RResult> RemoveMasterIfDetailNotExists(long gatePassID, CancellationToken cancellationToken)
        {
            RResult rResult = new();
            var dbEntity = await GetIC_GatepassMasterDetailInfoByID(gatePassID, cancellationToken);
            if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.SampleGmts)
            {
                var detail = await dbCon.IC_SampleGatePassDetail.Where(x => x.SampleGatePassID == gatePassID && x.IsActive == true && x.IsRemoved == false).ToListAsync();
                if (detail.Count == 0)
                {
                    dbEntity.IC_SampleGatePassMaster.IsRemoved = true;
                    dbEntity.IsRemoved = true;
                }
            }
            else if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.LocalSales)
            {
                var detail = await dbCon.IC_LocalSalesGatePassDetail.Where(x => x.LocalSalesGatePassID == gatePassID && x.IsActive == true && x.IsRemoved == false).ToListAsync(cancellationToken);
                if (detail.Count == 0)
                {
                    dbEntity.IC_LocalSalesGatePassMaster.IsRemoved = true;
                    dbEntity.IsRemoved = true;
                }
            }
            else if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.NonReturnable)
            {
                var detail = await dbCon.IC_NonReturnableGatePassDetail.Where(x => x.NonReturnableGatePassID == gatePassID && x.IsActive == true && x.IsRemoved == false).ToListAsync(cancellationToken);
                if (detail.Count == 0)
                {
                    dbEntity.IC_NonReturnableGatePassMaster.IsRemoved = true;
                    dbEntity.IsRemoved = true;
                }
            }
            else if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.Returnable)
            {
                var detail = await dbCon.IC_ReturnableGatePassDetail.Where(x => x.ReturnableGatePassID == gatePassID && x.IsActive == true && x.IsRemoved == false).ToListAsync(cancellationToken);
                if (detail.Count == 0)
                {
                    dbEntity.IC_ReturnableGatePassMaster.IsRemoved = true;
                    dbEntity.IsRemoved = true;
                }
            }
            else if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.ExportSales)
            {
                var detail = await dbCon.IC_ExportSalesGatePassDetail.Where(x => x.ExportSalesGatePassID == gatePassID && x.IsActive == true && x.IsRemoved == false).ToListAsync(cancellationToken);
                if (detail.Count == 0)
                {
                    dbEntity.IC_ExportSalesGatePassMaster.IsRemoved = true;
                    dbEntity.IsRemoved = true;
                }
            }
            else if (dbEntity.CategoryID == IC_DocumentCategoriesIDCC.ScrapSales)
            {
                var detail = await dbCon.IC_ScrapSalesGatePassDetail.Where(x => x.ScrapSalesGatePassID == gatePassID && x.IsActive == true && x.IsRemoved == false).ToListAsync(cancellationToken);
                if (detail.Count == 0)
                {
                    dbEntity.IC_ScrapSalesGatePassMaster.IsRemoved = true;
                    dbEntity.IsRemoved = true;
                }
            }
            else
            {

            }
            if (dbEntity.IsRemoved)
            {
                dbEntity.DeletedBy = _currentUserService.UserID;
                dbEntity.DeletedOn = DateTime.Now;
                await dbCon.SaveChangesAsync(cancellationToken);
                rResult.result = 1;
                rResult.message = ReturnMessage.DeleteMessage;
            }
            return rResult;
        }

        public async Task<RResult> SaveGatepassMaster(IC_GatepassMaster entity, CancellationToken cancellationToken)
        {
            RResult rResult = new();
            try
            {

                await dbCon.IC_GatepassMaster.AddAsync(entity, cancellationToken);
                await dbCon.SaveChangesAsync(cancellationToken);
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return rResult;
        }

        public async Task<RResult> UpdateGatepassMaster(IC_GatepassMaster entity, CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();
            dbCon.IC_GatepassMaster.Update(entity);
            await dbCon.SaveChangesAsync(cancellationToken);
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }

        public async Task<RResult> UpdateGatepassMasterDetail(IC_GatepassMaster entity, CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();
            try
            {
                var dbEntity = await GetIC_GatepassMasterDetailInfoByID(entity.ID, cancellationToken);
                if (dbEntity != null)
                {
                    //update Main Master
                    dbEntity.VehicleNo = entity.VehicleNo;
                    dbCon.IC_GatepassMaster.Update(dbEntity);

                    if (entity.CategoryID == IC_DocumentCategoriesIDCC.SampleGmts)
                    {
                        UpdateSampleGatePassMaster(dbEntity, entity);
                    }
                    else if (entity.CategoryID == IC_DocumentCategoriesIDCC.LocalSales)
                    {
                        UpdateLocalSalesGatepassMaster(dbEntity, entity);
                    }
                    else if (entity.CategoryID == IC_DocumentCategoriesIDCC.NonReturnable)
                    {
                        UpdateNonReturnableGatepassMaster(dbEntity, entity);
                    }
                    else if (entity.CategoryID == IC_DocumentCategoriesIDCC.Returnable)
                    {
                        UpdateReturnableGatepassMaster(dbEntity, entity);
                    }
                    else if (entity.CategoryID == IC_DocumentCategoriesIDCC.ExportSales)
                    {
                        UpdateExportSalesGatepassMaster(dbEntity, entity);
                    }
                    else if (entity.CategoryID == IC_DocumentCategoriesIDCC.ScrapSales)
                    {
                        UpdateScrapSalesGatepassMaster(dbEntity, entity);
                    }
                    else
                    {

                    }
                    await dbCon.SaveChangesAsync(cancellationToken);
                    dbCon.Entry(dbEntity).State = EntityState.Detached;

                    //Remove master if detail not exists
                    var removeResult = await RemoveMasterIfDetailNotExists(entity.ID, cancellationToken);
                    rResult.result = 1;
                    //if (removeResult.result == 1)
                    //{
                    //    rResult.result = 2;
                    //}

                    rResult.message = ReturnMessage.UpdateMessage;

                }
                else
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.ErrorMessage;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }

        private async Task<List<GatePassAccountIssueRM>> GetLocalSalesGatePassAccountIssueList(GatePassAccountIssueQM reqModel, CancellationToken cancellationToken)
        {


            var categoryID = reqModel.CategoryID == 0 ? 2 : reqModel.CategoryID;
            bool? isApprovedByAccounts = reqModel.ApprovalType == null ? null : Convert.ToBoolean(reqModel.ApprovalType);

            var localSalesData = await (from gm in dbCon.IC_GatepassMaster
                                        join ic in dbCon.IC_DocumentCategories on gm.CategoryID equals ic.ID
                                        join lsm in dbCon.IC_LocalSalesGatePassMaster on gm.ID equals lsm.GatePassID
                                        join d in dbCon.IC_Department on lsm.DepartmentID equals d.ID
                                        where gm.CategoryID == categoryID && gm.IsActive == true && gm.IsRemoved == false
                                                && reqModel.AccessablePaymentMode.Contains(lsm.PaymentMode.Value)
                                                && gm.IsApprovedByAccounts == isApprovedByAccounts
                                                && (reqModel.DateFrom == null || gm.DateTimeStamp.Value.Date >= reqModel.DateFrom)
                                                && (reqModel.DateTo == null || gm.DateTimeStamp.Value.Date <= reqModel.DateTo)
                                        select new GatePassAccountIssueRM
                                        {
                                            CategoryID = gm.CategoryID,
                                            GatePassID = gm.ID,
                                            CategoryName = ic.Name,
                                            SerialNo = gm.Serial,
                                            CreatedDate = gm.DateTimeStamp.Value.ToString("dd-MMM-yyyy"),
                                            CreatedTime = gm.DateTimeStamp.Value.ToString("h:mm tt"),
                                            Department = d.Name,
                                            CA_UserID = gm.CreatedBy,
                                            IsApprovedByAccounts = gm.IsApprovedByAccounts,
                                            Status = gm.IsApprovedByAccounts == null ? "Not Approved" : gm.IsApprovedByAccounts == true ? "Approved" : "Rejected",
                                        }).ToListAsync(cancellationToken);
            return localSalesData;
        }
        private async Task<List<GatePassAccountIssueRM>> GetScrapGatePassAccountIssueList(GatePassAccountIssueQM reqModel, CancellationToken cancellationToken)
        {
            var categoryID = reqModel.CategoryID == 0 ? 6 : reqModel.CategoryID;
            bool? isApprovedByAccounts = reqModel.ApprovalType == null ? null : Convert.ToBoolean(reqModel.ApprovalType);

            var scraplSalesData = await (from gm in dbCon.IC_GatepassMaster
                                         join ic in dbCon.IC_DocumentCategories on gm.CategoryID equals ic.ID
                                         join ssm in dbCon.IC_ScrapSalesGatePassMaster on gm.ID equals ssm.GatePassID
                                         join d in dbCon.IC_Department on ssm.DepartmentId equals d.ID
                                         where gm.CategoryID == categoryID
                                         && reqModel.AccessablePaymentMode.Contains(ssm.PaymentMode.Value)
                                         && gm.IsApprovedByAccounts == isApprovedByAccounts
                                                 && (reqModel.DateFrom == null || gm.DateTimeStamp.Value.Date >= reqModel.DateFrom)
                                                 && (reqModel.DateTo == null || gm.DateTimeStamp.Value.Date <= reqModel.DateTo)
                                         select new GatePassAccountIssueRM
                                         {
                                             CategoryID = gm.CategoryID,
                                             GatePassID = gm.ID,
                                             CategoryName = ic.Name,
                                             SerialNo = gm.Serial,
                                             CreatedDate = gm.DateTimeStamp.Value.ToString("dd-MMM-yyyy"),
                                             CreatedTime = gm.DateTimeStamp.Value.ToString("h:mm tt"),
                                             Department = d.Name,
                                             CA_UserID = gm.CreatedBy,
                                             IsApprovedByAccounts = gm.IsApprovedByAccounts,
                                             Status = gm.IsApprovedByAccounts == null ? "Not Approved" : gm.IsApprovedByAccounts == true ? "Approved" : "Rejected",
                                         }).ToListAsync(cancellationToken);
            return scraplSalesData;
        }
        private void UpdateSampleGatePassMaster(IC_GatepassMaster dbEntity, IC_GatepassMaster entity)
        {
            //update Master
            dbEntity.IC_SampleGatePassMaster.SampleProcessTypeID = entity.IC_SampleGatePassMaster.SampleProcessTypeID;
            dbEntity.IC_SampleGatePassMaster.CustomerTypeID = entity.IC_SampleGatePassMaster.CustomerTypeID;
            dbEntity.IC_SampleGatePassMaster.CustomerID = entity.IC_SampleGatePassMaster.CustomerID;
            dbEntity.IC_SampleGatePassMaster.CustomerName = entity.IC_SampleGatePassMaster.CustomerName;
            dbEntity.IC_SampleGatePassMaster.OrderID = entity.IC_SampleGatePassMaster.OrderID;
            dbEntity.IC_SampleGatePassMaster.ReferenceNo = entity.IC_SampleGatePassMaster.ReferenceNo;
            dbEntity.IC_SampleGatePassMaster.SampleDescription = entity.IC_SampleGatePassMaster.SampleDescription;
            dbEntity.IC_SampleGatePassMaster.WeightSlipNo = entity.IC_SampleGatePassMaster.WeightSlipNo;
            dbEntity.IC_SampleGatePassMaster.CarrierName = entity.IC_SampleGatePassMaster.CarrierName;
            dbEntity.IC_SampleGatePassMaster.DepartmentID = entity.IC_SampleGatePassMaster.DepartmentID;
            dbCon.IC_SampleGatePassMaster.Update(dbEntity.IC_SampleGatePassMaster);

            //Remove child
            foreach (var existingChild in dbEntity.IC_SampleGatePassMaster.IC_SampleGatePassDetail.ToList())
            {
                if (!entity.IC_SampleGatePassMaster.IC_SampleGatePassDetail.Any(c => c.ID == existingChild.ID))
                {
                    existingChild.IsRemoved = true;
                    dbCon.IC_SampleGatePassDetail.Update(existingChild);
                }
            }
            //Add or Update Child
            foreach (var childModel in entity.IC_SampleGatePassMaster.IC_SampleGatePassDetail)
            {
                var existingChild = dbEntity.IC_SampleGatePassMaster.IC_SampleGatePassDetail
                    .Where(c => c.ID == childModel.ID && c.ID != default(int))
                    .SingleOrDefault();

                if (existingChild != null)
                {// Update child                   
                    existingChild.ItemName = childModel.ItemName;
                    existingChild.Quantity = childModel.Quantity;
                    existingChild.UnitID = childModel.UnitID;
                    existingChild.Remarks = childModel.Remarks;
                    dbCon.IC_SampleGatePassDetail.Update(existingChild);
                }
                else
                {// Insert child                    
                    dbEntity.IC_SampleGatePassMaster.IC_SampleGatePassDetail.Add(childModel);
                }
            }
        }
        private void UpdateLocalSalesGatepassMaster(IC_GatepassMaster dbEntity, IC_GatepassMaster entity)
        {
            //update Master
            dbEntity.IC_LocalSalesGatePassMaster.CustomerID = entity.IC_LocalSalesGatePassMaster.CustomerID;
            dbEntity.IC_LocalSalesGatePassMaster.DepartmentID = entity.IC_LocalSalesGatePassMaster.DepartmentID;
            dbEntity.IC_LocalSalesGatePassMaster.IsSelfVehicle = entity.IC_LocalSalesGatePassMaster.IsSelfVehicle;
            dbCon.IC_LocalSalesGatePassMaster.Update(dbEntity.IC_LocalSalesGatePassMaster);

            //Remove child
            foreach (var existingChild in dbEntity.IC_LocalSalesGatePassMaster.IC_LocalSalesGatePassDetail.ToList())
            {
                if (!entity.IC_LocalSalesGatePassMaster.IC_LocalSalesGatePassDetail.Any(c => c.ID == existingChild.ID))
                {
                    existingChild.IsRemoved = true;
                    dbCon.IC_LocalSalesGatePassDetail.Update(existingChild);
                }
            }
            //Add or Update Child
            foreach (var childModel in entity.IC_LocalSalesGatePassMaster.IC_LocalSalesGatePassDetail)
            {
                var existingChild = dbEntity.IC_LocalSalesGatePassMaster.IC_LocalSalesGatePassDetail
                    .Where(c => c.ID == childModel.ID && c.ID != default(int))
                    .SingleOrDefault();

                if (existingChild != null)
                {// Update child
                    existingChild.OrderID = childModel.OrderID;
                    existingChild.OrderName = childModel.OrderName;
                    existingChild.PaymentMode = childModel.PaymentMode;
                    existingChild.OrderNo = childModel.OrderNo;
                    existingChild.ProcessCodeID = childModel.ProcessCodeID;
                    existingChild.ColorFinishCode = childModel.ColorFinishCode;
                    existingChild.Quantity = childModel.Quantity;
                    existingChild.UnitID = childModel.UnitID;
                    existingChild.Rate = childModel.Rate;
                    existingChild.GrossWeight = childModel.GrossWeight;
                    existingChild.NetWeight = childModel.NetWeight;
                    existingChild.Remarks = childModel.Remarks;
                    existingChild.ProcessID = childModel.ProcessID;
                    existingChild.ItemType = childModel.ItemType;
                    dbCon.IC_LocalSalesGatePassDetail.Update(existingChild);
                }
                else
                {// Insert child                    
                    dbEntity.IC_LocalSalesGatePassMaster.IC_LocalSalesGatePassDetail.Add(childModel);
                }
            }
        }
        private void UpdateNonReturnableGatepassMaster(IC_GatepassMaster dbEntity, IC_GatepassMaster entity)
        {
            //update Master
            dbEntity.IC_NonReturnableGatePassMaster.IssuedToID = entity.IC_NonReturnableGatePassMaster.IssuedToID;
            dbEntity.IC_NonReturnableGatePassMaster.Purpose = entity.IC_NonReturnableGatePassMaster.Purpose;
            dbEntity.IC_NonReturnableGatePassMaster.DepartmentID = entity.IC_NonReturnableGatePassMaster.DepartmentID;
            dbCon.IC_NonReturnableGatePassMaster.Update(dbEntity.IC_NonReturnableGatePassMaster);

            //Remove child
            foreach (var existingChild in dbEntity.IC_NonReturnableGatePassMaster.IC_NonReturnableGatePassDetail.ToList())
            {
                if (!entity.IC_NonReturnableGatePassMaster.IC_NonReturnableGatePassDetail.Any(c => c.ID == existingChild.ID))
                {
                    existingChild.IsRemoved = true;
                    dbCon.IC_NonReturnableGatePassDetail.Update(existingChild);
                }
            }
            //Add or Update Child
            foreach (var childModel in entity.IC_NonReturnableGatePassMaster.IC_NonReturnableGatePassDetail)
            {
                var existingChild = dbEntity.IC_NonReturnableGatePassMaster.IC_NonReturnableGatePassDetail
                    .Where(c => c.ID == childModel.ID && c.ID != default(int))
                    .SingleOrDefault();

                if (existingChild != null)
                {// Update child                   
                    existingChild.ItemName = childModel.ItemName;
                    existingChild.Quantity = childModel.Quantity;
                    existingChild.UnitID = childModel.UnitID;
                    existingChild.GrossWeight = childModel.GrossWeight;
                    existingChild.Remarks = childModel.Remarks;
                    dbCon.IC_NonReturnableGatePassDetail.Update(existingChild);
                }
                else
                {// Insert child                    
                    dbEntity.IC_NonReturnableGatePassMaster.IC_NonReturnableGatePassDetail.Add(childModel);
                }
            }
        }
        private void UpdateReturnableGatepassMaster(IC_GatepassMaster dbEntity, IC_GatepassMaster entity)
        {
            //update Master
            dbEntity.IC_ReturnableGatePassMaster.IssuedTo = entity.IC_ReturnableGatePassMaster.IssuedTo;
            dbEntity.IC_ReturnableGatePassMaster.VendorID = entity.IC_ReturnableGatePassMaster.VendorID;
            dbEntity.IC_ReturnableGatePassMaster.isSelfVehicle = entity.IC_ReturnableGatePassMaster.isSelfVehicle;
            dbEntity.IC_ReturnableGatePassMaster.Representative = entity.IC_ReturnableGatePassMaster.Representative;
            dbEntity.IC_ReturnableGatePassMaster.NarrowGroupId = entity.IC_ReturnableGatePassMaster.NarrowGroupId;
            dbEntity.IC_ReturnableGatePassMaster.IdentificationId = entity.IC_ReturnableGatePassMaster.IdentificationId;
            dbEntity.IC_ReturnableGatePassMaster.RepresentativeContact = entity.IC_ReturnableGatePassMaster.RepresentativeContact;
            dbEntity.IC_ReturnableGatePassMaster.HRMSID = entity.IC_ReturnableGatePassMaster.HRMSID;
            dbEntity.IC_ReturnableGatePassMaster.JobDesc = entity.IC_ReturnableGatePassMaster.JobDesc;
            dbCon.IC_ReturnableGatePassMaster.Update(dbEntity.IC_ReturnableGatePassMaster);

            //Remove child
            foreach (var existingChild in dbEntity.IC_ReturnableGatePassMaster.IC_ReturnableGatePassDetail.ToList())
            {
                if (!entity.IC_ReturnableGatePassMaster.IC_ReturnableGatePassDetail.Any(c => c.ID == existingChild.ID))
                {
                    existingChild.IsRemoved = true;
                    dbCon.IC_ReturnableGatePassDetail.Update(existingChild);
                }
            }
            //Add or Update Child
            foreach (var childModel in entity.IC_ReturnableGatePassMaster.IC_ReturnableGatePassDetail)
            {
                var existingChild = dbEntity.IC_ReturnableGatePassMaster.IC_ReturnableGatePassDetail
                    .Where(c => c.ID == childModel.ID && c.ID != default(int))
                    .SingleOrDefault();

                if (existingChild != null)
                {// Update child
                    existingChild.ReturnableItemCategoryID = childModel.ReturnableItemCategoryID;
                    existingChild.RequisitionID = childModel.RequisitionID;
                    existingChild.ItemName = childModel.ItemName;
                    existingChild.Quantity = childModel.Quantity;
                    existingChild.UnitID = childModel.UnitID;
                    existingChild.GrossWeight = childModel.GrossWeight;
                    existingChild.ExpectedReturnDate = childModel.ExpectedReturnDate;
                    existingChild.Remarks = childModel.Remarks;
                    dbCon.IC_ReturnableGatePassDetail.Update(existingChild);
                }
                else
                {// Insert child                    
                    dbEntity.IC_ReturnableGatePassMaster.IC_ReturnableGatePassDetail.Add(childModel);
                }
            }
        }
        private void UpdateExportSalesGatepassMaster(IC_GatepassMaster dbEntity, IC_GatepassMaster entity)
        {
            //update Master
            dbEntity.IC_ExportSalesGatePassMaster.CustomerId = entity.IC_ExportSalesGatePassMaster.CustomerId;
            dbEntity.IC_ExportSalesGatePassMaster.Purpose = entity.IC_ExportSalesGatePassMaster.Purpose;
            dbEntity.IC_ExportSalesGatePassMaster.VehicleRef = entity.IC_ExportSalesGatePassMaster.VehicleRef;
            dbEntity.IC_ExportSalesGatePassMaster.Description = entity.IC_ExportSalesGatePassMaster.Description;
            dbEntity.IC_ExportSalesGatePassMaster.DriverName = entity.IC_ExportSalesGatePassMaster.DriverName;
            dbEntity.IC_ExportSalesGatePassMaster.MobileNo = entity.IC_ExportSalesGatePassMaster.MobileNo;
            dbEntity.IC_ExportSalesGatePassMaster.TransportServiceName = entity.IC_ExportSalesGatePassMaster.TransportServiceName;

            dbCon.IC_ExportSalesGatePassMaster.Update(dbEntity.IC_ExportSalesGatePassMaster);

            //Remove child
            foreach (var existingChild in dbEntity.IC_ExportSalesGatePassMaster.IC_ExportSalesGatePassDetail.ToList())
            {
                if (!entity.IC_ExportSalesGatePassMaster.IC_ExportSalesGatePassDetail.Any(c => c.Id == existingChild.Id))
                {
                    existingChild.IsRemoved = true;
                    dbCon.IC_ExportSalesGatePassDetail.Update(existingChild);
                }
            }
            //Add or Update Child
            foreach (var childModel in entity.IC_ExportSalesGatePassMaster.IC_ExportSalesGatePassDetail)
            {
                var existingChild = dbEntity.IC_ExportSalesGatePassMaster.IC_ExportSalesGatePassDetail
                    .Where(c => c.Id == childModel.Id && c.Id != default(int))
                    .SingleOrDefault();

                if (existingChild != null)
                {// Update child                   
                    existingChild.ItemName = childModel.ItemName;
                    existingChild.UnitId = childModel.UnitId;
                    existingChild.InvoiceNumber = childModel.InvoiceNumber;
                    existingChild.FormENo = childModel.FormENo;
                    existingChild.ContainerNo = childModel.ContainerNo;
                    existingChild.ContainerSize = childModel.ContainerSize;
                    existingChild.BuyerName = childModel.BuyerName;
                    existingChild.ClearingAgent = childModel.ClearingAgent;
                    existingChild.SealNo = childModel.SealNo;
                    existingChild.ShippingLine = childModel.ShippingLine;
                    existingChild.Remarks = childModel.Remarks;
                    existingChild.Quantity = childModel.Quantity;
                    existingChild.CartonQty = childModel.CartonQty;
                    existingChild.BuyerID = childModel.BuyerID;
                    existingChild.OrderID = childModel.OrderID;
                    existingChild.CountryID = childModel.CountryID;

                    dbCon.IC_ExportSalesGatePassDetail.Update(existingChild);
                }
                else
                {// Insert child                    
                    dbEntity.IC_ExportSalesGatePassMaster.IC_ExportSalesGatePassDetail.Add(childModel);
                }
            }
        }
        private void UpdateScrapSalesGatepassMaster(IC_GatepassMaster dbEntity, IC_GatepassMaster entity)
        {
            //update Master
            dbEntity.IC_ScrapSalesGatePassMaster.ScrapCustomerID = entity.IC_ScrapSalesGatePassMaster.ScrapCustomerID;
            dbEntity.IC_ScrapSalesGatePassMaster.DepartmentId = entity.IC_ScrapSalesGatePassMaster.DepartmentId;
            dbEntity.IC_ScrapSalesGatePassMaster.VehicleDriverMobileNo = entity.IC_ScrapSalesGatePassMaster.VehicleDriverMobileNo;
            dbEntity.IC_ScrapSalesGatePassMaster.Description = entity.IC_ScrapSalesGatePassMaster.Description;
            dbEntity.IC_ScrapSalesGatePassMaster.IsSelfVehicle = entity.IC_ScrapSalesGatePassMaster.IsSelfVehicle;
            dbCon.IC_ScrapSalesGatePassMaster.Update(dbEntity.IC_ScrapSalesGatePassMaster);

            //Remove child
            foreach (var existingChild in dbEntity.IC_ScrapSalesGatePassMaster.IC_ScrapSalesGatePassDetail.ToList())
            {
                if (!entity.IC_ScrapSalesGatePassMaster.IC_ScrapSalesGatePassDetail.Any(c => c.ID == existingChild.ID))
                {
                    existingChild.IsRemoved = true;
                    dbCon.IC_ScrapSalesGatePassDetail.Update(existingChild);
                }
            }
            //Add or Update Child
            foreach (var childModel in entity.IC_ScrapSalesGatePassMaster.IC_ScrapSalesGatePassDetail)
            {
                var existingChild = dbEntity.IC_ScrapSalesGatePassMaster.IC_ScrapSalesGatePassDetail
                    .Where(c => c.ID == childModel.ID && c.ID != default(int))
                    .SingleOrDefault();

                if (existingChild != null)
                {// Update child                   
                    existingChild.ItemName = childModel.ItemName;
                    existingChild.Quantity = childModel.Quantity;
                    existingChild.UnitID = childModel.UnitID;
                    existingChild.Rate = childModel.Rate;
                    existingChild.Remarks = childModel.Remarks;
                    dbCon.IC_ScrapSalesGatePassDetail.Update(existingChild);
                }
                else
                {// Insert child                    
                    dbEntity.IC_ScrapSalesGatePassMaster.IC_ScrapSalesGatePassDetail.Add(childModel);
                }
            }
        }

        public async Task<bool> IsApprovedGatePass(long gatePassID, CancellationToken cancellationToken)
        {
            var gatePass = await GetByIdAsync(gatePassID, cancellationToken);
            if (gatePass != null)
            {
                if ((gatePass.isApproved != null && gatePass.isApproved.Value)
                    || (gatePass.IsApprovedByAccounts != null && gatePass.IsApprovedByAccounts.Value))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ExportSalesItemVM>> GetExportSalesItem(long GatePassID, CancellationToken cancellationToken)
        {
            var data = await dbCon.IC_ExportSalesGatePassDetail.Where(b => b.IsRemoved == false && b.IsActive == true && b.ExportSalesGatePassID == GatePassID)
                .Select(x => new ExportSalesItemVM()
                {
                    ID = x.Id,
                    ItemName = x.ItemName,
                    UnitID = x.UnitId,
                    InvoiceNumber = x.InvoiceNumber ?? "",
                    BuyerID = x.BuyerID,
                    BuyerName = x.BuyerName,
                    ClearingAgent = x.ClearingAgent ?? "",
                    Seal = x.SealNo ?? "",
                    ShippingLine = x.ShippingLine ?? "",
                    Remarks = x.Remarks ?? "",
                    Quantity = x.Quantity,
                    CartonQuantity = x.CartonQty,
                    FromE = x.FormENo ?? "",
                    Container = x.ContainerNo ?? "",
                    ContainerSize = x.ContainerSize ?? "",
                    OrderID = x.OrderID,
                    CountryID = x.CountryID,
                }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<ReturnableItemVM>> GetReturnableItem(long GatePassID, CancellationToken cancellationToken)
        {
            var query = await dbCon.IC_ReturnableGatePassDetail
                .Where(w => w.IsRemoved == false && w.IsActive == true && w.ReturnableGatePassID == GatePassID)
                .Select(s => new ReturnableItemVM()
                {
                    GrossWeight = s.GrossWeight,
                    ID = s.ID,
                    ItemName = s.ItemName,
                    Quantity = s.Quantity,
                    Remarks = s.Remarks,
                    RequisitionID = s.RequisitionID,
                    ReturnableItemCategoryID = s.ReturnableItemCategoryID,
                    ReturnDate = s.ExpectedReturnDate.ToString("dd-MMM-yyyy"),
                    UnitID = s.UnitID,

                })
                .ToListAsync(cancellationToken);
            return query;
        }

        public async Task<List<LocalSalesItemVM>> GetLocalSalesItem(long GatePassID, CancellationToken cancellationToken)
        {
            var data = await (from d in dbCon.IC_LocalSalesGatePassDetail
                              join m in dbCon.IC_LocalSalesGatePassMaster on d.LocalSalesGatePassID equals m.GatePassID
                              where d.IsRemoved == false && d.IsActive == true && d.LocalSalesGatePassID == GatePassID
                              && m.IsRemoved == false && m.IsActive == true
                              select new LocalSalesItemVM()
                              {
                                  ID = d.ID,
                                  FinishCode = d.ColorFinishCode,
                                  IssuanceDetailID = d.IssuanceDetailID,
                                  GrossWeight = d.GrossWeight,
                                  ItemDetail = d.ItemType,
                                  NetWeight = d.NetWeight,
                                  ProcessCode = d.ProcessCodeID,
                                  PaymentMode = m.PaymentMode,
                                  ProcessId = d.ProcessID,
                                  //ProcessName = model.ProcessList.Where(y => y.Value == x.ProcessId.Value.ToString()).First().Text,
                                  Quantity = d.Quantity,
                                  Rate = d.Rate,
                                  Remarks = d.Remarks,
                                  RollCount = d.Roll,
                                  UnitID = d.UnitID,
                                  //UnitOfMeasurement = model.UnitOfMeasurementList.Where(z => z.Value == x.UnitID.ToString()).First().Text,
                                  WorkOrderNo = d.OrderNo,
                                  OrderID = d.OrderID,
                                  OrderName = d.OrderName,
                                  RefNo = d.RefNo,
                                  GreigeWidth = d.GreigeWidth,
                                  FinishedWidth = d.FinishedWidth

                              }).ToListAsync(cancellationToken);

            return data;
        }
    }
}
