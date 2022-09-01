using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public partial class mm_PaymentTerm
    {
        public int ID { get; set; }
        public string PaymentTerm { get; set; }
        public int PaymentModeID { get; set; }
    }
}
