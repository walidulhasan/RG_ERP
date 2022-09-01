using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblPendinglotNotificationComments
    {
        public long Id { get; set; }
        public string Lotno { get; set; }
        public string Comments { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}
