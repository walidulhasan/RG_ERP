using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_Versions:DefaultTableProperties
    {
        public Plan_Versions()
        {
            Plan_StyleFabrics = new List<Plan_StyleFabrics>();
        }
        public int PlanVersionID { get; set; }
        public int VersionNo { get; set; }
        [ForeignKey("Plan_OrderMaster")]
        public int PlanID { get; set; }        
        public List<Plan_StyleFabrics> Plan_StyleFabrics { get; set; }
        public virtual Plan_OrderMaster Plan_OrderMaster { get; set; }
    }
}
