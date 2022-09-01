using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel
{
    public class WeeklyShipmentStatusRM
    {
        public long Period_ID { get; set; }
        public String Period_Name { get; set; }
        public DateTime Period_Start { get; set; }
        public DateTime Period_End { get; set; }
        public string WeekPeriodMsg { get { return $"{Period_Start:dd-MMM-yyyy} to {Period_End:dd-MMM-yyyy}"; } }
        public int Period_Year { get; set; }
        public string ExportMonth { get; set; }
        public int ScheduleShipment { get; set; }
        public int NoOfOrder { get; set; }
        public int NoOfInvoice { get; set; }
        public long InvoiceQty { get; set; }
        public decimal InvoiceAmt { get; set; }
        public decimal NegotiateAmt { get; set; }
        public decimal ReceivedAmt { get; set; }
        public decimal OutstandingAmt { get; set; }

    }
}
