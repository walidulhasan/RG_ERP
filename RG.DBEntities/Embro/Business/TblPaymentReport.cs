﻿using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class TblPaymentReport
    {
        public decimal? Amount { get; set; }
        public string Company { get; set; }
        public string CoaTag { get; set; }
        public string NrGroup { get; set; }
        public string Identification { get; set; }
        public string Item { get; set; }
    }
}
