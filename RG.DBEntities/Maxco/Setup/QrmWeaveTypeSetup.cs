﻿using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class QrmWeaveTypeSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int FabricCategoryId { get; set; }
    }
}
