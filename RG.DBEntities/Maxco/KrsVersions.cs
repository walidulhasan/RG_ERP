using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class KrsVersions
    {
        public int Id { get; set; }
        public int Krsvid { get; set; }
        public string Versionxml { get; set; }
        public int Krsid { get; set; }
    }
}
