﻿using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class EfvinvoiceInfo
    {
        public int Id { get; set; }
        public long? InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public long? VoucherId { get; set; }
        public decimal? Payment { get; set; }
    }
}
