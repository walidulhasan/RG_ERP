using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel
{
    public class LCMaturityRealizeRM
    {
        public long LcId { get; set; }
        public string LcCode { get; set; }
        public string LcNo { get; set; }
        public long SupplierID { get; set; }
        public long LcBankId { get; set; }
        public string LcItem { get; set; }
        public string PINo { get; set; }
        public string FundType { get; set; }
        public decimal LcValue { get; set; }
        public DateTime BankMaturityDate { get; set; }
        public decimal MaturityAmount { get; set; }
        public string Supplier { get; set; }
        public string Company { get; set; }
        public decimal CompanyID { get; set; }
        public string BankName { get; set; }
        public int ExportQty { get; set; }
        public decimal ExportValue { get; set; }
        public int OrderQty { get; set; }
        public decimal ExpectedValue { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
