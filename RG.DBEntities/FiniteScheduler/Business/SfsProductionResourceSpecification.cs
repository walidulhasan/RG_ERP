using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsProductionResourceSpecification
    {
        public int SfsPrsid { get; set; }
        public int SfsPrtypeId { get; set; }
        public string Name { get; set; }
        public int? IsAllBuyer { get; set; }
        public int? IsAllFabricType { get; set; }
        public int? IsAllGarmentCategory { get; set; }
        public int? IsAllGarmentType { get; set; }
        public byte? FabricCategoryId { get; set; }
        public int? UserId { get; set; }
        public int? HeadUserId { get; set; }

        public virtual SfsProductionResourceType SfsPrtype { get; set; }
    }
}
