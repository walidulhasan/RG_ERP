﻿using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class PnlAddLineItem
    {
        public int Id { get; set; }
        public int? CId { get; set; }
        public string LineItem { get; set; }
        public bool? IsAddition { get; set; }
        public int? Priority { get; set; }
        public int? CompId { get; set; }
    }
}
