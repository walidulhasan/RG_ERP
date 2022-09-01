using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MuPage2
    {
        public int Id { get; set; }
        public double? PageId { get; set; }
        public string PageName { get; set; }
        public string PageLink { get; set; }
        public double? ModuleId { get; set; }
        public double? PageTypeId { get; set; }
    }
}
