using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoIssuanceMaster
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Woid { get; set; }
        public DateTime IssuanceDate { get; set; }
    }
}
