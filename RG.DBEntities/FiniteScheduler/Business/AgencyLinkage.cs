using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyLinkage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int JobTicketId { get; set; }
        public long JobTicketNo { get; set; }
        public int CadcamjobId { get; set; }
        public int Status { get; set; }
        public int IssuanceMasterId { get; set; }
        public long ChallanNo { get; set; }
        public int AgencyId { get; set; }
        public decimal MrpitemCode { get; set; }
        public bool IsGarment { get; set; }
        public double? Quantity { get; set; }
        public DateTime TransDate { get; set; }
        public int? DocumentTypeId { get; set; }
        public long PieceId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long AttributeInstanceId { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public string AgencyDesc { get; set; }
    }
}
