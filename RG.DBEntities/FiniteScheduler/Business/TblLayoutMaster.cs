using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblLayoutMaster
    {
        public int Id { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? Orderid { get; set; }
        public long? Styleid { get; set; }
        public string LineNo { get; set; }
        public string Pantonno { get; set; }
        public long? Userid { get; set; }
    }
}
