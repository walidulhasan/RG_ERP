using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class RecurringEntries
    {
        public decimal Id { get; set; }
        public string Title { get; set; }
        public decimal VoucherId { get; set; }
    }
}
