using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class LeaseAssetsContractWise
    {
        [Key, Column(Order = 0)]
        [ForeignKey("FixedAsset")]
        public int AssetiD { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("LeaseLoanPayment")]
        public int LeaseID { get; set; }
        public int? AssetCoaid { get; set; }
        public bool? Status { get; set; }
        public int? VersionNo { get; set; }

        public virtual FixedAsset FixedAsset { get; set; }
        public virtual LeaseLoanPayment LeaseLoanPayment { get; set; }
    }
}
