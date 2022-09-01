using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_OrderMaster : DefaultTableProperties
    {
        public Plan_OrderMaster()
        {
            Plan_Versions = new List<Plan_Versions>();
        }
        public int PlanID { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderReceiveDate { get; set; }
        [NotMapped]
        public string OrderReceiveDateMsg { get { return OrderReceiveDate.ToString("dd-MMM-yyyy"); } }
        public List<Plan_Versions> Plan_Versions { get; set; }
    }
}
