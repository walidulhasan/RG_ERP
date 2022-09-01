using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Business
{
    public interface IDailyMailEmbroRepository
    {
        Task<List<DelayedVoucherPostingRM>> DelayedVoucherPostingRBL(DateTime DateFrom);
        Task<List<DelayedVoucherPostingRM>> DelayedVoucherPostingCBL(DateTime DateFrom);
    }
}
