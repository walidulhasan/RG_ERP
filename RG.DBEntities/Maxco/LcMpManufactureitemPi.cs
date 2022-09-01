using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcMpManufactureitemPi
    {
        public int Id { get; set; }
        public int LmpId { get; set; }
        public string LmpCode { get; set; }
        public int LpoId { get; set; }
    }
}
