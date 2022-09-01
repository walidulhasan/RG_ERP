using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Infrastructure.Persistence.MaxcoDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Business
{
    public class DailyMailMaxcoRepository : IDailyMailMaxcoRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public DailyMailMaxcoRepository(MaxcoDBContext dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<FDBP_FDBCEntryNotificationRM>> FDBP_FDBCEntryNotification()
        {
            var itemList = new List<FDBP_FDBCEntryNotificationRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_FDBP_Notification", commandTimeout: 500)

                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<FDBP_FDBCEntryNotificationRM>() as List<FDBP_FDBCEntryNotificationRM>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
