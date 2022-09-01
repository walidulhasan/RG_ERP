using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.DailyMail.Queries.RequestResponseModel
{
    public class OverdueHnMInvoicesNotificationRM
    {
        public string Period_Name { get; set; }
        public string EPIM_SHIPEDTO { get; set; }
        public string companyname { get; set; }
        public string BuyerName { get; set; }
        public string OrderNo { get; set; }
        public string EPIM_INVOICENO { get; set; }
        public string EPIM_DATE { get; set; }
        public string ExFactoryDate { get; set; }
        public string SubmissionDate { get; set; }
        public decimal EPIM_AMOUNT { get; set; }
        public double Received { get; set; }
        public string Paymentdate { get; set; }
        public int Overdue { get; set; }
        public int CompanyID { get; set; }
        public string EPM_SHIPMENTMODE { get; set; }
        public string Remarks { get; set; }

    }
}
