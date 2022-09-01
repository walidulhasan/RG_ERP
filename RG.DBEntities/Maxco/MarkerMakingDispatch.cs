using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MarkerMakingDispatch
    {
        public MarkerMakingDispatch()
        {
            MarkerMakingDispatchDetail = new HashSet<MarkerMakingDispatchDetail>();
        }

        public long Id { get; set; }
        public long StyleId { get; set; }
        public long? DispatchNo { get; set; }
        public int? VersionNo { get; set; }
        public DateTime CreationDate { get; set; }
        public byte Status { get; set; }
        public long StockId { get; set; }
        public double Quantity { get; set; }
        public long OrderId { get; set; }
        public double? UsedQuantity { get; set; }
        public int? FsRequirementSheetFabricsId { get; set; }
        public string LotNo { get; set; }
        public byte? Isroll { get; set; }

        public virtual ICollection<MarkerMakingDispatchDetail> MarkerMakingDispatchDetail { get; set; }
    }
}
