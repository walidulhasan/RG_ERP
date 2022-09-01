using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsMiratHand
    {
        public int Id { get; set; }
        public int JobTicketId { get; set; }
        public int PatternPieceId { get; set; }
        public int MrpitemCode { get; set; }
        public int FabricColorId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int AttributeInstanceId { get; set; }
        public int AtHandQty { get; set; }
        public int? RejectedQty { get; set; }
        public DateTime? Date { get; set; }
    }
}
