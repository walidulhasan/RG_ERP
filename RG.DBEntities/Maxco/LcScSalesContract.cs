using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcScSalesContract
    {
        public int Id { get; set; }
        public int LscId { get; set; }
        public string LscCode { get; set; }
        public DateTime LscLastmoddate { get; set; }
        public short LscModuserid { get; set; }
        public string LscTransactionmode { get; set; }
        public byte LscBuyerid { get; set; }
        public string LscBuyerbank { get; set; }
        public int LscCompanyId { get; set; }
        public int LscCompanybankId { get; set; }
        public int LscCompanybankaccountId { get; set; }
        public byte LscIspartialshipment { get; set; }
        public byte LscIsviashipment { get; set; }
        public int LscIssuancecityid { get; set; }
        public DateTime LscDateofissuance { get; set; }
        public int LscExpirycityid { get; set; }
        public DateTime LscDateofexpiry { get; set; }
        public int LscCurrencyid { get; set; }
        public string LscGoodsdescription { get; set; }
        public int LbsId { get; set; }
        public decimal LscOrderquantity { get; set; }
        public decimal LscOrdervalue { get; set; }
    }
}
