using System;

namespace RG.DBEntities.AOP.Business
{
    public class tbl_challan_master
    {
        public long challan_id { get; set; }
        public string customername { get; set; }
        public long? user_id { get; set; }
        public DateTime? creationdate { get; set; }
        public long? payment_mode { get; set; }
        public long? Currency { get; set; }
        public long? payment_term { get; set; }
        public decimal? amount { get; set; }
        public decimal? quantity { get; set; }
        public long? status { get; set; }
        public string customer_order_no { get; set; }
        public string address { get; set; }
        public string Phone { get; set; }

        public string Fax { get; set; }
        public string contact_person { get; set; }
        public int? Order_For { get; set; }
        public long? SupplierID { get; set; }
        public long? Ac_SupplierID { get; set; }

    }
}
