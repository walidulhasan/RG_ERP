using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWeighingBagWise
    {
        public int Id { get; set; }
        public int? TempRecId { get; set; }
        public int? Poid { get; set; }
        public string Lcno { get; set; }
        public int? AttributeInstanceId { get; set; }
        public string LotNo { get; set; }
        public string BagName { get; set; }
        public string GrossBagWeight { get; set; }
        public string NetBagWeight { get; set; }
    }
}
