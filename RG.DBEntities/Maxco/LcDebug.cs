using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcDebug
    {
        public int Id { get; set; }
        public int Did { get; set; }
        public string Tbl { get; set; }
        public string Xml { get; set; }
    }
}
