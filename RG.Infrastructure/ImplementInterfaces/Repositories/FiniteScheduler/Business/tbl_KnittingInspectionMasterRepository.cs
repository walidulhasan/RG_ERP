using AutoMapper;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.DBEntities.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class tbl_KnittingInspectionMasterRepository : GenericRepository<tbl_KnittingInspectionMaster>, Itbl_KnittingInspectionMasterRepository
    {
        private FiniteSchedulerDBContext dbCon;
        private readonly IMapper mapper;
        public tbl_KnittingInspectionMasterRepository(FiniteSchedulerDBContext context, IMapper mapper)
            : base(context)
        {
            dbCon = context;
            this.mapper = mapper;
        }
     /*   public async Task<RResult> SaveRollsGSMFinishedWidth(List<tbl_KnittingStockTransactionViewModel> KnittingStockTransaction, int JobId, int createdBy, bool saveChanges = true)
        {
            RResult rResult = new RResult();
            try
            {
                var inspectionMaster = new tbl_KnittingInspectionMaster()
                {
                    JobID = JobId,
                    InspectionDate=DateTime.Now,
                    KnittingFabricSpecificationID = 0,
                    IsLabTest = false,
                    
                };
                dbCon.tbl_KnittingInspectionMaster.Add(inspectionMaster);
                await dbCon.SaveChangesAsync();
                var knittingStockTransaction = mapper.Map<List<tbl_KnittingStockTransactionViewModel>, List<tbl_KnittingStockTransaction>>(KnittingStockTransaction);
                knittingStockTransaction.ForEach(x => { x.DocumentNo = inspectionMaster.InspectionID; x.DocumentTypeID = (int)enum_KnittingDocumentType.LabTest;});
                dbCon.tbl_KnittingStockTransaction.AddRange(knittingStockTransaction);              
               
                foreach (var roll in KnittingStockTransaction)
                {
                    var knittingRoll = dbCon.tbl_KnittingRolls.Where(x => x.RollID == roll.RollID).First();
                    var updatedRoll = knittingRoll;
                    updatedRoll.Status = 2;                   
                    dbCon.Entry(knittingRoll).CurrentValues.SetValues(updatedRoll);
                }
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
                throw new Exception(e.Message);
            }
            return rResult;
        }

        public async Task<RResult> SaveYKNCInspection(List<tbl_KnittingStockTransactionViewModel> KnittingStockTransaction, int JobId, int createdBy, bool saveChanges = true)
        {   
            RResult rResult = new RResult();
            try
            {
                var inspectionMaster = new tbl_KnittingInspectionMaster()
                {
                    JobID = JobId,
                    InspectionDate = DateTime.Now,
                    KnittingFabricSpecificationID = 0,
                    IsLabTest = false,
                };
                dbCon.tbl_KnittingInspectionMaster.Add(inspectionMaster);

                #region Rolls Lab Test
                ///////
                /// Roll are not tested here now, thats why the status for lab test (3) is now overlaped by the next task Inspection status (4)
                /// If needed in future, uncomment function RollsLabTest(StockTransaction,createdBy) and comment current codes for status (4)
                ///////

                //RollsLabTest(StockTransaction,createdBy);

                #endregion

                var issuanceMaster = new tbl_KnittingIssuanceMaster()
                {
                    IssuanceNo = "RIM-",
                    IssuanceDate = DateTime.Now,                    
                };
                dbCon.tbl_KnittingIssuanceMaster.Add(issuanceMaster);
                await dbCon.SaveChangesAsync();

                var updateIssuance = issuanceMaster;
                updateIssuance.IssuanceNo += Convert.ToString(issuanceMaster.IssuanceID);
                dbCon.Entry(issuanceMaster).CurrentValues.SetValues(updateIssuance);

                var transactionList = new List<tbl_KnittingStockTransaction>();
                foreach (var itemRoll in KnittingStockTransaction)
                {
                    var transaction = new tbl_KnittingStockTransaction()
                    {
                        DocumentTypeID = (int)enum_KnittingDocumentType.JobIssuance,
                        DocumentNo = issuanceMaster.IssuanceID,
                        RollID = itemRoll.RollID,
                        RollWeight = itemRoll.RollWeight,
                        Width = itemRoll.Width,
                        GSM = itemRoll.GSM,
                        JobID = itemRoll.JobID                        
                    };
                    transactionList.Add(transaction);
                }
                dbCon.tbl_KnittingStockTransaction.AddRange(transactionList);

                foreach (var roll in KnittingStockTransaction)
                {
                    var knittingRoll = dbCon.tbl_KnittingRolls.Where(x => x.RollID == roll.RollID).First();
                    var updatedRoll = knittingRoll;
                    updatedRoll.Status = 4;
                    updatedRoll.QualityID = roll.QualityID;                    
                    dbCon.Entry(knittingRoll).CurrentValues.SetValues(updatedRoll);
                }
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;

            }
            catch (Exception e)
            {
                rResult.result = 0;
                rResult.message = ReturnMessage.ErrorMessage;
                throw new Exception(e.Message);
            }
            return rResult;
        }
        */
        //private void RollsLabTest(List<tbl_KnittingStockTransactionViewModel> stockTransaction, int createdBy)
        //{
        //    try
        //    {
        //        foreach (var roll in stockTransaction)
        //        {
        //            var knittingRoll = dbCon.tbl_KnittingRolls.Where(x => x.RollID == roll.RollID).First();
        //            var updatedRoll = knittingRoll;
        //            updatedRoll.Status = 3;
        //            updatedRoll.QualityID = roll.QualityID;
        //            updatedRoll.UpdatedBy = createdBy;
        //            updatedRoll.UpdatedDate = DateTime.Now;
        //            dbCon.Entry(knittingRoll).CurrentValues.SetValues(updatedRoll);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
