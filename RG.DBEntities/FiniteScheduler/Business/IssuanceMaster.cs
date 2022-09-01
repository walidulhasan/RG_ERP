using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class IssuanceMaster
    {
        public int IssuanceMasterId { get; set; }
        public string IssuanceChallanNo { get; set; }
        public int UserId { get; set; }
        public DateTime Dated { get; set; }
        public int IssuanceFrom { get; set; }
        public int IssuedTo { get; set; }
        public int JobTicketId { get; set; }
        public string Comments { get; set; }
    }
}
