using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_PartialRequisition_Master 
    {
  
        public long ID { get; set; }
        public DateTime? ReqDate { get; set; }
        public long? OrderID { get; set; }
        public long? UserID { get; set; }
        public long? CompanyID { get; set; }
        public long? BusinessID { get; set; }
        public long? LocationID { get; set; }
        public long? CostCentreID { get; set; }
        public string SubLocation { get; set; }
        public virtual ICollection<MM_PartialRequisition_Detail> MM_PartialRequisition_Detail { get; set; }
    }
}
