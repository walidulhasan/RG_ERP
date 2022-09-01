using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using RG.Application.Common.Models;
using RG.DBEntities.MaterialsManagement.Business;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class tbl_knittingGateRepository : GenericRepository<tbl_knittingGate>, Itbl_knittingGateRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public tbl_knittingGateRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }

        /*
        public async Task<RResult> SaveInitialGateReceiving(tbl_knittingGateViewModel knittingGate, double totalQty, List<Yarn_KnittingContractDetail> ykncDetail, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var model = mapper.Map<tbl_knittingGateViewModel, tbl_knittingGate>(knittingGate);
                var jobId = Convert.ToInt32(dbCon.tbl_KnittingJobs.Where(j => j.YarnKnittingContractID == model.YKNC).First().JobID);
                model.Date = DateTime.Now;
                model.JobID = jobId;

                string latestRollCode = await GetLatestRollCode(jobId, model.YKNC);
                var GateKnittingRollsList = new List<tbl_GateKnittingRolls>();
                var gateKnittingRollsID = (await GetTableMaxId("RollID", "long", "FiniteScheduler.dbo.tbl_GateKnittingRolls")).longID;
                for (int i = 0; i < model.NoOfRolls; i++)
                {
                    var rollModel = new tbl_GateKnittingRolls
                    {
                        RollID = ++gateKnittingRollsID,
                        JobID = jobId,
                        RollCode = latestRollCode.Remove(latestRollCode.Length - 4) + Convert.ToString(Convert.ToInt32(latestRollCode.Substring(latestRollCode.Length - 4)) + i).PadLeft(4, '0'),
                        Status = 1,
                        QualityID = 1,
                        ParentID = 0
                    };
                    GateKnittingRollsList.Add(rollModel);
                }
                model.tbl_GateKnittingRolls = GateKnittingRollsList;
                var pickListMasterDetail = GeneratePickListMasterDetail(jobId, model.YKNC, totalQty, ykncDetail, createdBy);

                dbCon.tbl_knittingGate.Add(model);
                dbCon.tbl_KnittingPickListMaster.Add(pickListMasterDetail);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.longId = model.ID;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
        */
        private tbl_KnittingPickListMaster GeneratePickListMasterDetail(int jobId, long yKNCId, double totalQty, List<Yarn_KnittingContractDetail> ykncDetail, int createdBy)
        {
            var pickListMaster = new tbl_KnittingPickListMaster();
            try
            {
                pickListMaster.YarnKnittingContractID = yKNCId;
                pickListMaster.JobID = jobId;
                pickListMaster.ReceivingPersonName = "N/A";
                pickListMaster.PickListNo = "PKL-00";
                pickListMaster.CreationDate = DateTime.Now;
                pickListMaster.Acknowledge = 0;
                pickListMaster.YarnReceivingDate = DateTime.Now;
                var pickListDetail = new List<tbl_KnittingPickListDetail>();
                foreach (var item in ykncDetail)
                {
                    var detail = new tbl_KnittingPickListDetail
                    {
                        AttributeInstanceID = item.AttributeInstanceID,
                        Quantity = (item.Utilization.Value / 100) * totalQty,
                    };
                    pickListDetail.Add(detail);
                }
                pickListMaster.tbl_KnittingPickListDetail = pickListDetail;

                var subPickList = new tbl_KnittingSubPickListMaster
                {
                    ReceivingPersonName = "N/A",
                    SubPickListNo = "SPKL-000-0",
                    CreationDate = DateTime.Now,
                    Acknowledge = 1,
                    YarnIssuanceStatus = 0,
                    YarnReceivingDate = DateTime.Now
                };

                var subPickListDetail = new List<tbl_KnittingSubPickListDetail>();
                foreach (var item in ykncDetail)
                {
                    var detail = new tbl_KnittingSubPickListDetail
                    {
                        UnitID = 1,//default
                        AttributeInstanceID = item.AttributeInstanceID,
                        Quantity = (item.Utilization.Value / 100) * totalQty,
                        BatchDescription = "Batch Description",
                        ReceivingQuantity = 0
                    };
                    subPickListDetail.Add(detail);
                }
                subPickList.tbl_KnittingSubPickListDetail = subPickListDetail;

                pickListMaster.tbl_KnittingSubPickListMaster = subPickList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return pickListMaster;
        }
      
        private async Task<string> GetLatestRollCode(int jobId, int YKNCId)
        {
            try
            {
                var latestRollCode = "YKNC-" + YKNCId.ToString() + "-000-";
                var _jobID = Convert.ToInt64(jobId);
                var lastRoll = await dbCon.tbl_GateKnittingRolls.Where(r => r.JobID == _jobID).OrderByDescending(x => x.RollID).FirstOrDefaultAsync();
                if (lastRoll != null)
                {
                    var latestRollNo = Convert.ToInt32(lastRoll.RollCode.Substring(lastRoll.RollCode.Length - 4)) + 1;
                    latestRollCode = latestRollCode + latestRollNo.ToString().PadLeft(4, '0');
                }
                else
                {
                    latestRollCode = latestRollCode + "0000";
                }
                return latestRollCode;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
