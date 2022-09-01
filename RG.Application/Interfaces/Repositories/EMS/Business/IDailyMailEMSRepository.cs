using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.EMS.Business
{
    public interface IDailyMailEMSRepository
    {
        Task<List<OverdueHnMInvoicesNotificationRM>> OverdueHnMInvoicesNotification();
        Task<List<BTB_Cash_LC_OverdueMaturityNotificationRM>> BTB_Cash_LC_OverdueMaturityNotification();
        Task<List<DailyKnittingShiftAndMachineWiseKnittingDefectsRM>> DailyKnittingShiftAndMachineWiseKnittingDefects(DateTime? DtFrom = null, DateTime? DtTo = null);
    }
}
