using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel
{
    public class ExportDocumentRealizationDetailRM
    {
        public int EPIM_ID { get; set; }
        public string EPIM_INVOICENO { get; set; }
        public decimal EPIM_AMOUNT { get; set; }
        public decimal DollarAmt { get; set; }
        public decimal Balance { get; set; }
        public long FDBPI_MasterID { get; set; }
    }
}
