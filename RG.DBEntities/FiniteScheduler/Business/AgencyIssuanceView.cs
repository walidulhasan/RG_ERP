﻿using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyIssuanceView
    {
        public int DocumentTypeId { get; set; }
        public long AgencyIssuanceId { get; set; }
        public int AgencyId { get; set; }
        public long StyleId { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public double? Expr1 { get; set; }
    }
}
