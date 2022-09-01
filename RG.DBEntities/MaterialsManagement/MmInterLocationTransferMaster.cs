using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmInterLocationTransferMaster
    {
        public long Id { get; set; }
        public int? ModelId { get; set; }
        public int? OrderId { get; set; }
        public int? BuyerId { get; set; }
        public DateTime? InterLocationTransferDate { get; set; }
        public string Iltnumber { get; set; }
        public long? CompanyId { get; set; }
        public long? BusinessId { get; set; }
    }
}
