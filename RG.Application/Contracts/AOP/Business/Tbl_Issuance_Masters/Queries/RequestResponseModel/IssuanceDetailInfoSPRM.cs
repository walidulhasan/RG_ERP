using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries.RequestResponseModel
{
    public class IssuanceDetailInfoSPRM
    {
        public long challan_id { get; set; }
        public string f_type { get; set; }
        public string f_quality { get; set; }
        public string f_composition { get; set; }
        public string ItemName { get; set; }
        public string customer_order_no { get; set; }
        public long payment_mode { get; set; }
        public string PMDescription { get; set; }
        public string issue_date { get; set; }
        public long roll_qty { get; set; }
        public long issue_ID { get; set; }
        public string customername { get; set; }
        public string Design_code { get; set; }
        public long fab_id { get; set; }
        public string Color { get; set; }
        public string print_type { get; set; }
        public double f_gsm { get; set; }
        public double f_width { get; set; }
        public long Chest_printTypeID { get; set; }
        public string Chest_PrintType { get; set; }
        public string chest_deginCode { get; set; }
        public decimal Stitch { get; set; }
        public decimal PerThousand { get; set; }
        public string Buyer { get; set; }
        public string Style { get; set; }
        public string Jobno { get; set; }
        public decimal unit_price { get; set; }
        public decimal ReceivedQty { get; set; }
        public decimal IssueQty { get; set; }

        public decimal FinishedWidth { get; set; }
        public decimal GreigeWidth { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public string ReceivedChallanNo { get; set; }
        public decimal Value { get { return IssueQty * unit_price; } }
    }
}
