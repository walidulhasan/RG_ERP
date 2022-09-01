using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnPodeliveries
    {
        public YarnPodeliveries()
        {
            YarnReceiptDetail = new HashSet<YarnReceiptDetail>();
        }
        [Key]
        public int Mpodid { get; set; }
        public int YarnPodid { get; set; }
        public int DayId { get; set; }
        public double Quantity { get; set; }
        public double LeftOverQty { get; set; }
        public int UnitId { get; set; }
        public double ConversiontoSku { get; set; }
        public int? Status { get; set; }

        public virtual MrpitemUnits Unit { get; set; }
        public virtual YarnPodetail YarnPod { get; set; }
        public virtual ICollection<YarnReceiptDetail> YarnReceiptDetail { get; set; }
    }
}
