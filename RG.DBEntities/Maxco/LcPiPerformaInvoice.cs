using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcPiPerformaInvoice
    {
        public int Id { get; set; }
        public int LpiId { get; set; }
        public string LpiCode { get; set; }
        public string LpiDesc { get; set; }
        public DateTime LpiLastmoddate { get; set; }
        public int LpiModuserid { get; set; }
    }
}
