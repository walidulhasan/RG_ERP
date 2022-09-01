using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
   public partial class QRM_BuyerCostingAllowance
    {
        public int ID { get; set; }
        public int CostingAllowanceID { get; set; }
        public int BuyerID { get; set; }
        public double? Percentage { get; set; }
        public bool IsReadOnly { get; set; }
        public int? SerialNo { get; set; }
        public int ParentAllowanceID { get; set; }
        public bool? IsSimpleAddition { get; set; }
    }
}
