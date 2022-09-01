using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerRadioMaster
    {
        public long Id { get; set; }
        public long? Orderid { get; set; }
        public string Color { get; set; }
        public string Ftype { get; set; }
        public string Fquality { get; set; }
        public string Fcomposition { get; set; }
        public long? Userid { get; set; }
        public DateTime? Creationdate { get; set; }
        public decimal? MarkerLength { get; set; }
        public string RadioName { get; set; }
    }
}
