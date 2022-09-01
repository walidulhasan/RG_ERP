using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.EMS.Business;
using RG.Infrastructure.Persistence.EMSDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.EMS.Business
{
    public class DailyMailEMSRepository: IDailyMailEMSRepository
    {
        private readonly EMSDBContext _dbCon;

        public DailyMailEMSRepository(EMSDBContext dbCon) 
        {
            _dbCon = dbCon;
        }

        public async Task<List<BTB_Cash_LC_OverdueMaturityNotificationRM>> BTB_Cash_LC_OverdueMaturityNotification()
        {
            var data = new List<BTB_Cash_LC_OverdueMaturityNotificationRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_BTBOverDue", commandTimeout: 500)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<BTB_Cash_LC_OverdueMaturityNotificationRM>() as List<BTB_Cash_LC_OverdueMaturityNotificationRM>;
                                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<DailyKnittingShiftAndMachineWiseKnittingDefectsRM>> DailyKnittingShiftAndMachineWiseKnittingDefects(DateTime? DtFrom = null, DateTime? DtTo = null)
        {
            var data = new List<DailyKnittingShiftAndMachineWiseKnittingDefectsRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_IEReport2", commandTimeout: 500)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<DailyKnittingShiftAndMachineWiseKnittingDefectsRM>() as List<DailyKnittingShiftAndMachineWiseKnittingDefectsRM>;
                                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<OverdueHnMInvoicesNotificationRM>> OverdueHnMInvoicesNotification()
        {
            var data = new List<OverdueHnMInvoicesNotificationRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_Overdue_Invoices_Hnm", commandTimeout: 500)                                
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<OverdueHnMInvoicesNotificationRM>() as List<OverdueHnMInvoicesNotificationRM>;
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
