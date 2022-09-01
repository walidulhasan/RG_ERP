using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnBookingMaster
    {
        public long MasterId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
        public bool? IsBooked { get; set; }
    }
}
