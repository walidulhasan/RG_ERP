using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Setup
{
    public interface ISchedularReportEmailRepository :IGenericRepository<SchedularReportEmail>
    {

        /// <summary>
        /// emailTo,emailCc,emailBcc
        /// </summary>
        /// <param name="ReportName"></param>
        /// <returns>emailTo,emailCc,emailBcc</returns>
        Task<Tuple<List<string>, List<string>, List<string>>> GetMailRecipients(string ReportName);
         
    }
}
