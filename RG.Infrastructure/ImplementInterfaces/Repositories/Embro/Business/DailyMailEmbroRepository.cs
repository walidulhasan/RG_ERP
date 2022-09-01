using RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.Infrastructure.Persistence.EmbroDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Business
{
    public class DailyMailEmbroRepository : IDailyMailEmbroRepository
    {
        private readonly EmbroDBContext _dbCon;

        public DailyMailEmbroRepository(EmbroDBContext dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<DelayedVoucherPostingRM>> DelayedVoucherPostingCBL(DateTime DateFrom)
        {
            var data = new List<DelayedVoucherPostingRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_DelayedVoucher_Posting_Comptex", commandTimeout: 500)
                            .WithSqlParam(nameof(DateFrom), DateFrom)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<DelayedVoucherPostingRM>() as List<DelayedVoucherPostingRM>;
                                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<DelayedVoucherPostingRM>> DelayedVoucherPostingRBL(DateTime DateFrom)
        {
            var data = new List<DelayedVoucherPostingRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Mail_DelayedVoucher_Posting_Robintex", commandTimeout: 500)
                          .WithSqlParam(nameof(DateFrom), DateFrom)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<DelayedVoucherPostingRM>() as List<DelayedVoucherPostingRM>;
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
