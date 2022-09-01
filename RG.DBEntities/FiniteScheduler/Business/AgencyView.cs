using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyView
    {
        public int AgencyId { get; set; }
        public string AgencyDesc { get; set; }
        public long ChallanNo { get; set; }
        public decimal MrpitemCode { get; set; }
        public bool IsGarment { get; set; }
        public double? Quantity { get; set; }
        public DateTime TransDate { get; set; }
        public int? DocumentTypeId { get; set; }
        public string Comments { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long PieceId { get; set; }
        public long AttributeInstanceId { get; set; }
    }
}
