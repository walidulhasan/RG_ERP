using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel
{
    public class DocumentsPurchaseRatioRM
    {
        public decimal CompanyID { get; set; }
        public string Companyname { get; set; }
        public string CompanyShortName { get; set; }
        public string Buyer { get; set; }
        public string BankName { get; set; }
        public string LOM_CODE { get; set; }
        public int Year { get; set; }
        public string MonthName { get; set; }
        public int YearMonth { get; set; }
        public long FDBPP_ID { get; set; }
        public string DocumentNo { get; set; }
        public DateTime DocumentDate { get; set; }
        public string DocumentDateMsg { get { return DocumentDate.ToString("dd-MMM-yyyy"); } }
        public decimal DocumentAmt { get; set; }
        public decimal PurchasePercent { get; set; }
        public decimal PurchaseRatioAmt { get; set; }
        public double PurchaseAmt { get; set; }

    }
}
