using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ErrorLog
    {
        public int Id { get; set; }
        public int Eid { get; set; }
        public string ErrorXml { get; set; }
        public string DateX { get; set; }
    }
}
