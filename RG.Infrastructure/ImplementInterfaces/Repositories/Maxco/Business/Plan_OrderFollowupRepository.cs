using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.DBEntities.Maxco.Business;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Business
{
    public class Plan_OrderFollowupRepository : GenericRepository<Plan_OrderFollowup>, IPlan_OrderFollowupRepository
    {
        private readonly MaxcoDBContext dbCon;
        public Plan_OrderFollowupRepository(MaxcoDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<Plan_OrderFollowup> GetOrderPlanFollowup(int orderID, CancellationToken cancellationToken)
        {
            try
            {
                var data = await dbCon.Plan_OrderFollowup.Where(x => x.OrderID == orderID && x.IsActive == true && x.IsRemoved == false)
                .FirstOrDefaultAsync(cancellationToken);
                return data;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<RResult> Plan_OrderFollowupSave(Plan_OrderFollowup entity)
        {
            RResult rResult = new RResult();
            try
            {
                await dbCon.Plan_OrderFollowup.AddAsync(entity);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
                return rResult;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RResult> Plan_OrderFollowupUpdate(Plan_OrderFollowup entity)
        {
            RResult rResult = new RResult();
            try
            {
                var dbEntity = await GetByIdAsync(entity.FollowupID);
                dbEntity.OrderClassificationID = entity.OrderClassificationID;
                dbEntity.AdditionalFromStock = entity.AdditionalFromStock;
                dbEntity.ApprovedDate = entity.ApprovedDate;
                dbEntity.PackingCompleteDate = entity.PackingCompleteDate;
                dbEntity.PreFinalDate = entity.PreFinalDate;
                dbEntity.IsOrderClosed = entity.IsOrderClosed;
                dbEntity.ExpectedSampleDate = entity.ExpectedSampleDate;
                dbEntity.PreProductionSampleApprovalDate = entity.PreProductionSampleApprovalDate;
                dbEntity.Remarks = entity.Remarks;

                dbCon.Plan_OrderFollowup.Update(dbEntity);
                await dbCon.SaveChangesAsync();

                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
                return rResult;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
