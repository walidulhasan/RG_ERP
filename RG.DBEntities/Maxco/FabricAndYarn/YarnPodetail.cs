using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnPodetail
    {
        public YarnPodetail()
        {
            YarnPodeliveries = new HashSet<YarnPodeliveries>();
        }
        [Key]
        public int YarnPodid { get; set; }
        public int Mpmid { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public int SupplierId { get; set; }
        public int? BrandId { get; set; }
        public int? ObjectId { get; set; }
        public int? SuperBomid { get; set; }
        public double Rate { get; set; }
        public double Gst { get; set; }
        public int PackagingId { get; set; }
        public int WeightId { get; set; }
        public int NoOfPackagesId { get; set; }

        public virtual ICollection<YarnPodeliveries> YarnPodeliveries { get; set; }
    }
}
