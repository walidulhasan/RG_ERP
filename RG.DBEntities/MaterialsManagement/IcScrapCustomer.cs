using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcScrapCustomer
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public double? SecurityDeposit { get; set; }
        public long? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
    }
}
