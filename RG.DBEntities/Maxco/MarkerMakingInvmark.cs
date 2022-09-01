using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MarkerMakingInvmark
    {
        public int Id { get; set; }
        public MarkerMakingInvmark()
        {
            MarkerMakingInvmarkDetail = new HashSet<MarkerMakingInvmarkDetail>();
        }

        public long MarkerId { get; set; }
        public string MarkerName { get; set; }
        public decimal? ShrinkageL { get; set; }
        public decimal? ShrinkageW { get; set; }
        public decimal? FabricWmtr { get; set; }
        public decimal? FabricLmtr { get; set; }
        public decimal? MarkerLmtr { get; set; }
        public decimal? Efficiency { get; set; }
        public string SpreadingType { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public string MarkerStatus { get; set; }
        public string Section { get; set; }
        public string Season { get; set; }
        public string FabricType { get; set; }
        public string MarkerType { get; set; }

        public virtual ICollection<MarkerMakingInvmarkDetail> MarkerMakingInvmarkDetail { get; set; }
    }
}
