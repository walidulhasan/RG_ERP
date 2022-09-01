using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.ApprovalConfigMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class ApprovalConfigMasterRepository : GenericRepository<ApprovalConfigMaster>, IApprovalConfigMasterRepository
    {
        private readonly FiniteSchedulerDBContext dbCon;

        public ApprovalConfigMasterRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<ApprovalConfigMaster> GetModuleWiseApprovalConfig(ModuleWiseApprovalConfigQM queryModel, CancellationToken cancellationToken = default)
        {
            var data = await dbCon.ApprovalConfigMaster
                .Include(x => x.ApprovalConfigDetail.Where(y => y.IsActive == true && y.IsRemoved == false))
                .Where(x => x.ModuleName == queryModel.ModuleName
                && x.ConfigCompanyID == queryModel.ConfigCompanyID
                && x.ConfigOfficeDivisionID == queryModel.ConfigOfficeDivisionID
                && x.ConfigDepartmentID == queryModel.ConfigDepartmentID
                && x.ConfigSectionID == queryModel.ConfigSectionID
                && x.ConfigJobTitleID == queryModel.ConfigJobTitleID
                && x.IsActive == true && x.IsRemoved == false)
                .FirstOrDefaultAsync(cancellationToken);
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
                                  ApproverGroup = $"{ m.ModuleName.Replace(" ", "")}ApprovalLevel{d.ApprovalLevel}"
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
                await dbCon.ApprovalConfigDetail.AddRangeAsync(model);
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

        public async Task<RResult> UpdateApprovalConfigMaster(ApprovalConfigMaster model)
        {
            RResult rResult = new();
            dbCon.Update(model);
            await dbCon.SaveChangesAsync();

            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }


    }
}
