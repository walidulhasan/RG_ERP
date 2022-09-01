using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SubDomain
    {
        public int Id { get; set; }
        public int SubDomainId { get; set; }
        public string SubDomainDescription { get; set; }
        public int? DomainId { get; set; }
    }
}
