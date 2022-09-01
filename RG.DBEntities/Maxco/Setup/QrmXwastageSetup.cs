using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class QrmXwastageSetup
    {
        public int Id { get; set; }
        public int XwsId { get; set; }
        public int XwsFrom { get; set; }
        public int XwsTo { get; set; }
        public decimal XwsPercentage { get; set; }
        public string XwsCompName { get; set; }
        public string XwsDescr { get; set; }
    }
}
