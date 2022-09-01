using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VAgencyColorwiseTrack
    {
        public string Collection { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        public int Challan { get; set; }
        public DateTime ChallanFlowIssueDate { get; set; }
        public string AgencyName { get; set; }
        public string Description { get; set; }
        public string Htmlcode { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public string PatternPiece { get; set; }
        public double? Quantity { get; set; }
        public DateTime TransDate { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? CommentsId { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public string DocumentName { get; set; }
        public int JobTicketId { get; set; }
        public long JobTicketNo { get; set; }
    }
}
