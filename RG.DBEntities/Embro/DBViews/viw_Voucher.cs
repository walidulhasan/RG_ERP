using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Embro.DBViews
{
    public class viw_Voucher
    {
        public decimal VoucherId { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime VDate { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string VoucherDescription { get; set; }
        public long? Costcenter { get; set; }     
        public int? LocationID { get; set; }       
        public long? Activity { get; set; }

        public DateTime RDate { get; set; }

        public int CompanyId { get; set; }
        
        public int BusinessId { get; set; }
        public int? Vindex { get; set; }
        public long VID { get; set; }
        public decimal? PreparedBy { get; set; }
        public decimal? CheckedBy { get; set; }
        public decimal? AuthorizedBy { get; set; }
        public int? IndividualVoucherId { get; set; }
        public int? VoucherType { get; set; }
        public int? ParentId { get; set; }
        public int? NoOfDays { get; set; }
        public decimal? EntryType { get; set; }
        public decimal? CRate { get; set; }
        public int CurrencyID { get; set; }

    }
}
