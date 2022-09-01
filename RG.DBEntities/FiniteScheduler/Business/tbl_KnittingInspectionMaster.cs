using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
  public  class tbl_KnittingInspectionMaster
    {
        [Key]
        public long InspectionID { get; set; }
        public long JobID { get; set; }
        public DateTime InspectionDate { get; set; }
        public long KnittingFabricSpecificationID { get; set; }
        public bool? IsLabTest { get; set; }
    }
}
