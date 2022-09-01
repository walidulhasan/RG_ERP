using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblAgencyTransComments
    {
        public decimal DocId { get; set; }
        public int CommentsId { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public int DocumentTypeId { get; set; }
        public long? ChallanNo { get; set; }
    }
}
