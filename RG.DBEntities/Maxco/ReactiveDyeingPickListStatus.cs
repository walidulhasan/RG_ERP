using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ReactiveDyeingPickListStatus
    {
        public int Id { get; set; }
        public string LotNo { get; set; }
        public int LotPickList { get; set; }
        public int RecipePickList { get; set; }
        public int AdditionalPickList { get; set; }
    }
}
