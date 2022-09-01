using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonSubDomainLinks
    {
        [Key]
        public int SubDomainId { get; set; }
        public string LinkDescription { get; set; }
        public string Url { get; set; }
        public int SequenceNo { get; set; }
    }
}
