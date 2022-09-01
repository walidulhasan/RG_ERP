using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.Setup
{
    public class SchedularReportEmail
    {
        public int ID { get; set; }
        public string EmailReportKey { get; set; }
        public string EmailTO { get; set; }
        public string EmailCC { get; set; }
        public string EmailBCC { get; set; }

    }
}
