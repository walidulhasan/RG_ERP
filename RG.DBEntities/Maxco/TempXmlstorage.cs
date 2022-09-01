using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TempXmlstorage
    {
        public int Id { get; set; }
        public string Xmldata { get; set; }
        public DateTime AccessTime { get; set; }
    }
}
