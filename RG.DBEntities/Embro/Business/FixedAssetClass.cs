using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Business
{
    public partial class FixedAssetClass
    {
        public FixedAssetClass()
        {
            FixedAsset = new HashSet<FixedAsset>();
        }
        [Key]
        public int ClassID { get; set; }
        public string ClassGroupID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AccountDepriciationMethod_ID { get; set; }
        public int? TaxDepriciationMethod_ID { get; set; }
        public decimal? AccountDepriciationRate { get; set; }
        public decimal? TaxDepriciationRate1 { get; set; }
        public decimal? TaxDepriciationRate2 { get; set; }
        public decimal? TaxDepriciationRate3 { get; set; }
        public decimal? TaxDepriciationRateN { get; set; }
        public int? DepriciationPolicyID { get; set; }
        public virtual ICollection<FixedAsset> FixedAsset { get; set; }
    }
}
