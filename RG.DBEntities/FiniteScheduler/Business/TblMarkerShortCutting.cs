using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerShortCutting
    {
        public int MarkerShortId { get; set; }
        public int? UserId { get; set; }
        public DateTime? HDate { get; set; }
        public int? Companyid { get; set; }
        public int? Buyerid { get; set; }
        public long? OrderId { get; set; }
        public int? Layer { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? StyleId { get; set; }
        public string Rollno { get; set; }
        public string Pantonno { get; set; }
    }
}
