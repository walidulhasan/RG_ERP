using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
   public class tbl_Currency_Detail
    {
        public int ID { get; set; }
        public decimal? RateInPakRs { get; set; }
        public DateTime? Date { get; set; }
        public long? EnteredBy { get; set; }
        public long? CurId { get; set; }

        public tbl_Currency_Setup tbl_Currency_Setup { get; set; }

    }
}
