using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class CMBL_COAAssociationType
    {
        [Key]
        public int BG1ID { get; set; }
        public int COAID { get; set; }
        public int RelationID { get; set; }
        public int? DomainID { get; set; }
    }
}
