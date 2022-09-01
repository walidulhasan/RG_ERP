using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MuPage
    {
        public int Id { get; set; }
        public long PageId { get; set; }
        public string PageName { get; set; }
        public string PageLink { get; set; }
        public int ModuleId { get; set; }
        public int PageTypeId { get; set; }
    }
}
