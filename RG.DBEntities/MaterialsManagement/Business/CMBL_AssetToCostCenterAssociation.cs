using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class CMBL_AssetToCostCenterAssociation
    {
        [Key]
        public long ID { get; set; }
        public long COAID { get; set; }
        public long LocationID { get; set; }
        public long CostCenterID { get; set; }
        public long ActivityID { get; set; }
        public int? DomainID { get; set; }
    }
}
