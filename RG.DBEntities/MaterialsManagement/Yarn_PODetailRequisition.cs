using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Yarn_PODetailRequisition
    {
        public int ID { get; set; }
        public long Yarn_PODetailID { get; set; }
        public long YarnReqDetailID { get; set; }
        public double ReqQuantity { get; set; }
    }
}
