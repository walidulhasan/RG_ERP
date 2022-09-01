using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcOmOrderMaster
    {
        public LcOmOrderMaster()
        {
            LcMcMasterChild = new HashSet<LC_MC_MASTER_CHILD>();
        }
        public int Id { get; set; }
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
        public decimal? LomForeignbuyinghouseper { get; set; }
        public decimal? LomLocalbuyinghouseper { get; set; }
        public decimal? LomMiscellaneousper { get; set; }
        public decimal? LomValue { get; set; }
        public short? LtdId { get; set; }
        public decimal? LomTechcom { get; set; }
        public short? LmtId { get; set; }
        public double? LomUnitprice { get; set; }
        public decimal? LomQuantity { get; set; }
        public decimal? LomBalancequantity { get; set; }
        public double? LomBtbper { get; set; }
        public double? LomYarnper { get; set; }
        public double? LomKnitper { get; set; }
        public double? LomFabricdyeper { get; set; }
        public double? LomDyesper { get; set; }
        public double? LomPrintper { get; set; }
        public double? LomTrimsper { get; set; }
        public double? LomOthersper { get; set; }

        public virtual ICollection<LC_MC_MASTER_CHILD> LcMcMasterChild { get; set; }
    }
}
