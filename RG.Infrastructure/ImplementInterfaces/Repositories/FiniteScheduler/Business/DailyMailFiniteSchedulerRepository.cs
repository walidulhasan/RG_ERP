using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Business;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Business
{
    public class DailyMailFiniteSchedulerRepository : IDailyMailFiniteSchedulerRepository
    {
        private readonly FiniteSchedulerDBContext _dbCon;
        public DailyMailFiniteSchedulerRepository(FiniteSchedulerDBContext context)
        {
            _dbCon = context;
        }

        public async Task<List<DailyKnittingShiftAndMachineWiseOverallPerformanceRM>> DailyKnittingShiftAndMachineWiseOverallPerformance(DateTime? DtFrom = null, DateTime? DtTo = null)
        {
            List<DailyKnittingShiftAndMachineWiseOverallPerformanceRM> data = new();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_IE_Knitting_Overall_Performance", commandTimeout: 500)
                   .WithSqlParam(nameof(DtFrom), DtFrom)
                   .WithSqlParam(nameof(DtTo), DtTo)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       data = handler.ReadToList<DailyKnittingShiftAndMachineWiseOverallPerformanceRM>() as List<DailyKnittingShiftAndMachineWiseOverallPerformanceRM>;
                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<KnittingProductionDefectRM>> KnittingProductionDefect(DateTime? DtFrom=null)
        {
            List<KnittingProductionDefectRM> data = new();
            try
            {
                if (DtFrom.HasValue == false)
                {
                    DtFrom = DateTime.Now.Date;
                }
                await _dbCon.LoadStoredProc("rpt.Mail_IE_Report1",commandTimeout: 500)
                   .WithSqlParam(nameof(DtFrom), DtFrom.Value.Date)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       data = handler.ReadToList<KnittingProductionDefectRM>() as List<KnittingProductionDefectRM>;
                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<SubContractGatePassRM>> SubContractGatePass(DateTime? stdate = null, DateTime? todate = null)
        {
            List<SubContractGatePassRM> data = new();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_SubContract_Mail", commandTimeout: 500)
                   .WithSqlParam(nameof(stdate), stdate)
                   .WithSqlParam(nameof(todate), todate)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       data = handler.ReadToList<SubContractGatePassRM>() as List<SubContractGatePassRM>;
                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<Top_Cutting_DefectsRM>> Top_Cutting_Defects(DateTime? DtFrom = null, DateTime? DtTo = null)
        {
            List<Top_Cutting_DefectsRM> data = new();
            try
            {
                if (DtFrom.HasValue == false)
                {
                    DtFrom = DateTime.Now.AddDays(-1).Date;
                }
                await _dbCon.LoadStoredProc("rpt.Mail_top_cutting_defects", commandTimeout: 500)
                   .WithSqlParam(nameof(DtFrom), DtFrom.Value.Date)
                   .WithSqlParam("DtTo", DtFrom.Value.Date)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       data = handler.ReadToList<Top_Cutting_DefectsRM>() as List<Top_Cutting_DefectsRM>;
                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }
    }
}
