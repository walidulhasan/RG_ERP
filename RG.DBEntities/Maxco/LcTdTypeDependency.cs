using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class LcTdTypeDependency
    {
        public int Id { get; set; }
        public short LtdId { get; set; }
        public string LtdName { get; set; }
        public int LtsId { get; set; }

        public virtual LcTsTypeSetup Lts { get; set; }
    }
}
