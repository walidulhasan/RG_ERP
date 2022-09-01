using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SubDomainLinks2
    {
        public int Id { get; set; }
        public double? SubDomainId { get; set; }
        public string LinkDescription { get; set; }
        public string Url { get; set; }
        public double? SequenceNo { get; set; }
    }
}
