using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class CMBL_StoreBroadGroup
    {
        [Key]
        public int StoreID { get; set; }
        public long AttributeID { get; set; }
    }
}
