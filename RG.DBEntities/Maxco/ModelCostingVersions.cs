using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ModelCostingVersions
    {
        public int Id { get; set; }
        public int? VersionNo { get; set; }
        public int? UserId { get; set; }
        public int? CreationDate { get; set; }
    }
}
