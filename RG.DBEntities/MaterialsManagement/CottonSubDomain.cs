using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonSubDomain
    {
        [Key]
        public int SubDomainId { get; set; }
        public string SubDomainDescription { get; set; }
        public int? DomainId { get; set; }
    }
}
