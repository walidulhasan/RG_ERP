using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SubDomainLinks
    {
        public int Id { get; set; }
        public int SubDomainId { get; set; }
        public string LinkDescription { get; set; }
        public string Url { get; set; }
        public int SequenceNo { get; set; }
        public int? DomainId { get; set; }
    }
}
