using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDyeingLosttimeR
    {
        public int Id { get; set; }
        public int? McNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EndTimeD { get; set; }
        public long? UserId { get; set; }
        public string Remarks { get; set; }
        public string Comment { get; set; }
        public int? LostTypeId { get; set; }
    }
}
