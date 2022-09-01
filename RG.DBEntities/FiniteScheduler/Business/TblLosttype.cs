using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblLosttype
    {
        public int Id { get; set; }
        public string LostType { get; set; }
        public int? Serial { get; set; }
        public int? Catagory { get; set; }
    }
}
