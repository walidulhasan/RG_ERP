using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
    public interface IDailyMailFiniteSchedulerRepository
    {
        Task<List<KnittingProductionDefectRM>> KnittingProductionDefect(DateTime? DtFrom=null);
        Task<List<DailyKnittingShiftAndMachineWiseOverallPerformanceRM>> DailyKnittingShiftAndMachineWiseOverallPerformance(DateTime? DtFrom = null, DateTime? DtTo = null);
        Task<List<SubContractGatePassRM>> SubContractGatePass(DateTime? stdate = null, DateTime? todate = null);
        Task<List<Top_Cutting_DefectsRM>> Top_Cutting_Defects(DateTime? DtFrom = null, DateTime? DtTo = null);
    }
}
