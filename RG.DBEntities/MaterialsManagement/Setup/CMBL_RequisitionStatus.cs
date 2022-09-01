using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class CMBL_RequisitionStatus
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusDescription { get; set; }
    }
}
