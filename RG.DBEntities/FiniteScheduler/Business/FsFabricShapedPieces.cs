using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsFabricShapedPieces
    {
        public int Id { get; set; }
        public int MrpitemCode { get; set; }
        public int FabricCategoryId { get; set; }
    }
}
