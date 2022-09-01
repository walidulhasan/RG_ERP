using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ActionPerformed { get; set; }
        public DateTime? DateTime { get; set; }
        public string Xml { get; set; }
        public string ValueSaved { get; set; }
    }
}
