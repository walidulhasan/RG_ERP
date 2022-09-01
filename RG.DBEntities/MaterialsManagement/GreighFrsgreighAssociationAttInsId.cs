using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreighFrsgreighAssociationAttInsId
    {
        public int Id { get; set; }
        public long? Frsaid { get; set; }
        public long? Frsid { get; set; }
        public long? Gaid { get; set; }
        public long? Daid { get; set; }
        public int? Gsm { get; set; }
        public int? FinishWidth { get; set; }
    }
}
