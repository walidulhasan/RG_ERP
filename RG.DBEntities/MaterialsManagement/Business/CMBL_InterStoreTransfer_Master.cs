using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class CMBL_InterStoreTransfer_Master
    {
        [Key]
        public long ISTID { get; set; }
        public string ISTNO { get; set; }
        public long CompanyID { get; set; }
        public int Deleted { get; set; }
        public string Comments { get; set; }
        public DateTime ISTDate { get; set; }
        public int UserID { get; set; }
    }
}
