using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcMomMegaOrderMaster
    {
        public int Id { get; set; }
        public DateTime LmomCreationdate { get; set; }
        public int LmomId { get; set; }
        public int LomId { get; set; }
        public string LomCode { get; set; }
        public DateTime? LomLastmoddate { get; set; }
        public short? LomModuserid { get; set; }
        public string LomTransactionmode { get; set; }
        public byte LomBuyerid { get; set; }
        public string LomBuyerbank { get; set; }
        public short? LbsId { get; set; }
        public int LomCompanyId { get; set; }
        public int LomCompanybankId { get; set; }
        public int LomCompanybankaccountId { get; set; }
        public byte LomIspartialshipment { get; set; }
        public byte LomViashipment { get; set; }
        public int LomIssuancecityid { get; set; }
        public DateTime LomDateofissuance { get; set; }
        public int LomExpirycityid { get; set; }
        public DateTime LomDateofexpiry { get; set; }
        public int LomCurrencyid { get; set; }
        public string LomGooddescription { get; set; }
        public short? LomForeignbuyinghouseper { get; set; }
        public short? LomLocalbuyinghouseper { get; set; }
        public short? LomMiscellaneousper { get; set; }
        public decimal? LomValue { get; set; }
        public short? LtdId { get; set; }
        public short? LomTechcom { get; set; }
        public short? LmtId { get; set; }
        public double? LomUnitprice { get; set; }
        public decimal? LomQuantity { get; set; }
        public decimal? LomBalancequantity { get; set; }
    }
}
