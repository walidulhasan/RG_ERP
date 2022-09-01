using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel
{
    public class ExportDocumentRealizationRM
    {
        public long FDBPP_ID { get; set; }
        public string FDBPP_REFNO { get; set; }
        public long Period_ID { get; set; }
        public string Period_Name { get; set; }
        public int Period_Year { get; set; }
        public int NoOfInvoice { get; set; }
        public double InvoiceValue { get; set; }
        public decimal RealizeAmt { get; set; }
        public decimal FDBPP_Balance { get; set; }


        public int EPIM_ID { get; set; }
        public string EPIM_INVOICENO { get; set; }
        public decimal EPIM_AMOUNT { get; set; }
        public decimal DollarAmt { get; set; }
        public decimal Balance { get; set; }
        public long FDBPI_MasterID { get; set; }
    }
}
