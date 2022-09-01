using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class SelectedThreadPurpose
    {
        public int ID { get; set; }
        [ForeignKey("ThreadPurpose_Setup")]
        public int? PurposeID { get; set; }
        public int Status { get; set; }
        public int SelectedElementID { get; set; }

        public virtual ThreadPurpose_Setup ThreadPurpose_Setup { get; set; }
    }
}
