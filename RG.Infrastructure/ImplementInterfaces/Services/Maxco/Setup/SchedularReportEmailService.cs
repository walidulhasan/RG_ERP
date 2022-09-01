using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Setup
{
   public class SchedularReportEmailService: ISchedularReportEmailService
    {
        private readonly ISchedularReportEmailRepository _schedularReportEmailRepository;

        public SchedularReportEmailService(ISchedularReportEmailRepository schedularReportEmailRepository)
        {
            _schedularReportEmailRepository = schedularReportEmailRepository;
        }
    }
}
