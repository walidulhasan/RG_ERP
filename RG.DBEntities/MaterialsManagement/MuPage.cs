﻿using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MuPage
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageLink { get; set; }
        public int ModuleId { get; set; }
        public int PageTypeId { get; set; }
    }
}
