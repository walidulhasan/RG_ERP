using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class IcUserSetup
    {
        [Key]
        public long UserId { get; set; }
        public long ReportTo { get; set; }
        public long AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool? Active { get; set; }
        public bool? CanCreateUsers { get; set; }
        public bool? CanAuthorizeUsers { get; set; }
        public bool? CanAddScrapCustomers { get; set; }
        public bool? CanViewScrapCustomers { get; set; }
    }
}
