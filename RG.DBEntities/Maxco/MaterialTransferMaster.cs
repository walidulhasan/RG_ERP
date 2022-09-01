using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialTransferMaster
    {[Key]
        public int MtransferMid { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
