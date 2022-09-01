using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class CMBL_IssuanceWithRequisition
    {
        [Key]
        public long IssuanceID { get; set; }
        public int UserID { get; set; }
        public long CompanyID { get; set; }
        public long IssuanceNo { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string RecPerson { get; set; }
        public int Deleted { get; set; }
    }
}
