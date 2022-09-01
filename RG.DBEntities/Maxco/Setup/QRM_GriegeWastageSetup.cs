using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class QRM_GriegeWastageSetup
    {
        [Key]
        public int GWS_ID { get; set; }
        public int FabricTypeID { get; set; }
        public int GWS_FROM { get; set; }
        public int GWS_TO { get; set; }
        public decimal GWS_PERCENTAGE { get; set; }
        public string GWS_Name { get; set; }
    }
}
