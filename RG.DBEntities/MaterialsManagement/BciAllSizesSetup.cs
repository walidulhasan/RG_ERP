using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciAllSizesSetup
    {
        public int Id { get; set; }
        public int Sno { get; set; }
        public string Size { get; set; }
        public int FgtypeId { get; set; }
    }
}
