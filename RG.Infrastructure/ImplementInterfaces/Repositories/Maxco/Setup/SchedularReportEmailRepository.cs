using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.DBEntities.Maxco.Setup;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Setup
{
    public class SchedularReportEmailRepository : GenericRepository<SchedularReportEmail>, ISchedularReportEmailRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public SchedularReportEmailRepository(MaxcoDBContext maxcoDBContext) : base(maxcoDBContext)
        {
            _dbCon = maxcoDBContext;
        }

        public async Task<Tuple<List<string>, List<string>, List<string>>> GetMailRecipients(string ReportName)
        {
            var mailItem = await _dbCon.SchedularReportEmail
                .Where(b => b.EmailReportKey == ReportName)
                .FirstAsync();
            List<string> emailTo = new List<string>();
            List<string> emailCc = new List<string>();
            List<string> emailBcc = new List<string>();
            if (mailItem.EmailTO != null)
            {
                emailTo = mailItem.EmailTO.Split(',').ToList();
            }
            if (mailItem.EmailCC != null)
            {
                emailCc = mailItem.EmailCC.Split(',').ToList();
            }
            if (mailItem.EmailBCC != null)
            {
                emailBcc = mailItem.EmailBCC.Split(',').ToList();
            }
            return Tuple.Create(emailTo, emailCc, emailBcc);
        }
    }
}
