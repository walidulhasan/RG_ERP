using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class GwchainManualOperation
    {
        public long GwchainManualOperationId { get; set; }
        public long SequenceNo { get; set; }
      
        public long GwmanualOperationId { get; set; }
        public long GwchainId { get; set; }
        public int NoOfPersons { get; set; }
        public double Smv { get; set; }
        public int? ProcessSequence { get; set; }

        public virtual Gwchain Gwchain { get; set; }
    }
}
