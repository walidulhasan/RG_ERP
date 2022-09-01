using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsFabricMrpitemCode
    {
        public int Id { get; set; }
        public int MrpitemCode { get; set; }
        public int FabricTypeId { get; set; }
    }
}
