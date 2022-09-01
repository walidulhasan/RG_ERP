using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Commands.DataTransferModel;
using RG.Application.Contracts.AlgoHR.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class ApprovalConfigMasterRepository : GenericRepository<ApprovalConfigMaster>, IApprovalConfigMasterRepository
    {
        private readonly AlgoHRDBContext dbCon;

        public ApprovalConfigMasterRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<ApprovalConfigMaster> GetModuleWiseApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken = default)
        {
            var query = dbCon.ApprovalConfigMaster
                .Include(x => x.ApprovalConfigDetail.Where(y => y.IsActive == true && y.IsRemoved == false))
                .Where(x => x.ModuleName == queryModel.ModuleName
                && x.ConfigCompanyID == queryModel.ConfigCompanyID
                && x.ConfigOfficeDivisionID == queryModel.ConfigOfficeDivisionID
                && x.ConfigDepartmentID == queryModel.ConfigDepartmentID
                && x.ConfigSectionID == queryModel.ConfigSectionID
                && x.ConfigJobTitleID == queryModel.ConfigJobTitleID
                && x.IsActive == true && x.IsRemoved == false);
            //var queryTo = query.ToQueryString();
            //var aaa = await query.ToListAsync(cancellationToken);
            var data = await query.FirstOrDefaultAsync(cancellationToken);
            return data;
        }
        public async Task<ApprovalConfigMaster> GetModuleWiseApprovalConfig(int configMasterID, CancellationToken cancellationToken = default)
        {
            var data = await dbCon.ApprovalConfigMaster
               .Include(x => x.ApprovalConfigDetail.Where(y => y.IsActive == true && y.IsRemoved == false))
               .Where(x => x.ConfigMasterID == configMasterID
               && x.IsActive == true && x.IsRemoved == false)
               .FirstOrDefaultAsync(cancellationToken);
            return data;
        }
        public async Task<List<ApprovalConfigMaster>> GetEmployeeModuleWiseApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken = default)
        {
            var data = await dbCon.ApprovalConfigMaster
               .Include(x => x.ApprovalConfigDetail.Where(y => y.IsActive == true && y.IsRemoved == false))
               .Where(x => x.ModuleName == queryModel.ModuleName
               && x.ConfigCompanyID == queryModel.ConfigCompanyID
               && x.ConfigOfficeDivisionID == queryModel.ConfigOfficeDivisionID
               && x.IsActive == true && x.IsRemoved == false)
               .ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<UserApprovalPowerRM>> GetUserApprovalPower(int designationID, int employeeID, CancellationToken cancellationToken = default)
        {
            var data = await (from d in dbCon.ApprovalConfigDetail
                              join m in dbCon.ApprovalConfigMaster on d.ConfigMasterID equals m.ConfigMasterID
                              where m.IsActive == true && m.IsRemoved == false && d.IsActive == true && d.IsRemoved == false
                              && d.ApproverJobTitleID == designationID && (d.ApproverEmployeeID == null || d.ApproverEmployeeID == employeeID)
                              select new UserApprovalPowerRM
                              {
                                  ApproverDesignationID = d.ApproverJobTitleID,
                                  ApproverEmployeeID = d.ApproverEmployeeID,
                                  ApproverGroup = $"{employeeID}{ m.ModuleName.Replace(" ", "")}ApprovalLevel{d.ApprovalLevel}"
                              }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<RResult> RemoveApprovalConfigMasterByDetail(int masterID, int detailID, int updatedBy)
        {
            RResult rResult = new();
            var data = await dbCon.ApprovalConfigMaster
               .Include(x => x.ApprovalConfigDetail.Where(y => y.IsActive == true && y.IsRemoved == false))
               .Where(x => x.ConfigMasterID == masterID && x.IsActive == true && x.IsRemoved == false)
               .FirstOrDefaultAsync();

            data.ApprovalConfigDetail.Where(x => x.ConfigDetailID == detailID).ToList().ForEach(c => { c.IsRemoved = true; c.LastModifiedBy = updatedBy; c.LastModifiedDate = DateTime.Now; });
            if (data.ApprovalConfigDetail.Where(x => x.ConfigDetailID != detailID).ToList().Count == 0)
            {
                data.IsRemoved = false;
                data.LastModifiedBy = updatedBy;
                data.LastModifiedDate = DateTime.Now;
            }
            dbCon.Update(data);
            await dbCon.SaveChangesAsync();

            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }

        public async Task<RResult> SaveApprovalConfigMaster(ApprovalConfigMaster model)
        {
            RResult rResult = new RResult();
            try
            {
                await dbCon.ApprovalConfigMaster.AddAsync(model);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<RResult> SaveApprovalConfigDetail(List<ApprovalConfigDetail> model)
        {
            RResult rResult = new RResult();
            try
            {
                string message = "";
                int isExistingDetailsIdDelete = 0;
                var masterID = model.First().ConfigMasterID;
                var dbApprovers = await dbCon.ApprovalConfigDetail.Where(x => x.ConfigMasterID == masterID).ToListAsync();
                // Delete
                foreach (var approver in dbApprovers)
                {
                    if (!model.Any(c => c.ConfigDetailID == approver.ConfigDetailID))
                    {
                        var hasExistsNotification = await dbCon.ApprovalNotification.Where(b => b.IsRemoved == false && b.IsActive == true
                                            && b.ApprovalDetailID == approver.ConfigDetailID
                                            && b.IsChecked == false).FirstOrDefaultAsync();

                        if (hasExistsNotification != null && hasExistsNotification.ApprovalDetailID > 0)
                        {
                            isExistingDetailsIdDelete += 1;
                            message = $"Approval label {approver.ApprovalLevel} has exists notification. Contact this approver";
                            break;
                        }
                        else
                        {
                            approver.IsRemoved = true;
                            dbCon.Update(approver);
                        }
                    }
                }
                //Insert
                if (isExistingDetailsIdDelete == 0)
                {
                    foreach (var approver in model)
                    {
                        var isExists = dbApprovers
                              .Where(c => c.ConfigDetailID == approver.ConfigDetailID).FirstOrDefault();
                        if (isExists == null)
                        {
                            await dbCon.AddAsync(approver);
                        }
                        else
                        {
                            isExists.ApprovalLevel = approver.ApprovalLevel;
                            isExists.ApproverCompanyID = approver.ApproverCompanyID;
                            isExists.ApproverOfficeDivisionID = approver.ApproverOfficeDivisionID;
                            isExists.ApproverDepartmentID = approver.ApproverDepartmentID;
                            isExists.ApproverSectionID = approver.ApproverSectionID;
                            isExists.ApproverJobTitleID = approver.ApproverJobTitleID;
                            isExists.ApproverEmployeeID = approver.ApproverEmployeeID;
                            dbCon.Update(isExists);
                        }
                    }
                }

                if (isExistingDetailsIdDelete == 0)
                {
                    await dbCon.SaveChangesAsync();
                    rResult.result = 1;
                    rResult.message = ReturnMessage.InsertMessage;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = message;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<RResult> UpdateApprovalConfigMaster(ApprovalConfigMaster model)
        {
            RResult rResult = new();
            dbCon.Update(model);
            await dbCon.SaveChangesAsync();

            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }

        public async Task<RResult> ReplaceApprover(UpdateReplaceApproverDTM replaceApprover, CancellationToken cancellationToken)
        {
            RResult rResult = new();
            try
            {
                string query = $@"UPDATE ad SET ad.ApproverCompanyID={replaceApprover.ToCompanyID},ad.ApproverOfficeDivisionID={replaceApprover.ToDivisionID},ad.ApproverDepartmentID={replaceApprover.ToDepartmentID}
                                        ,ad.ApproverSectionID = {replaceApprover.ToSectionID},ad.ApproverJobTitleID = {replaceApprover.ToDesignationID},ad.ApproverEmployeeID = {replaceApprover.ToEmployeeID},ad.LastModifiedBy = {replaceApprover.LastModifiedBy},ad.LastModifiedDate = '{DateTime.Now}'
                                    FROM ajt.ApprovalConfigDetail ad
                                    JOIN ajt.ApprovalConfigMaster am on ad.ConfigMasterID = am.ConfigMasterID
                                    WHERE am.IsActive = 1 AND am.IsRemoved = 0 
                                        AND ad.IsActive = 1 AND ad.IsRemoved = 0
                                        AND am.ModuleName = '{replaceApprover.ModuleName}' AND ad.ApproverEmployeeID = {replaceApprover.FromEmployeeID}";
                dbCon.Database.ExecuteSqlRaw(query);
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = e.Message;
            }

            return rResult;
        }
    }
}
