using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QRM_BuyerTrimAssociation
    {
        public long ID { get; set; }
        public int? ItemSetupID { get; set; }
        public int? BuyerID { get; set; }
        public int? TrimID { get; set; }
    }
}
