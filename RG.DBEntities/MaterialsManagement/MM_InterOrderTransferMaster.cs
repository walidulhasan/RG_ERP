using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_InterOrderTransferMaster
    {
        [Key]
        public long IOID { get; set; }
        public int ModelID { get; set; }
        public int OrderID { get; set; }
        public int BuyerID { get; set; }
        public DateTime InterOrderDate { get; set; }
        public string IOTNumber { get; set; }
        public long? UserID { get; set; }
        public long? CompanyID { get; set; }
        public long? BusinessID { get; set; }
        public int? IsNetting { get; set; }
    }
}
