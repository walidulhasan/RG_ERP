using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public interface IDailyMailMaxcoRepository
    {
        Task<List<FDBP_FDBCEntryNotificationRM>> FDBP_FDBCEntryNotification();
    }
}
