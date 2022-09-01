using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class Gwchain
    {
        public Gwchain()
        {
            GwchainMachineOperation = new HashSet<GwchainMachineOperation>();
            GwchainManualOperation = new HashSet<GwchainManualOperation>();
        }
        [Key]
        public long GwchainId { get; set; }
        public long StyleId { get; set; }
        public long UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public double FinalSmv { get; set; }
        public double? Weight { get; set; }

        public virtual ICollection<GwchainMachineOperation> GwchainMachineOperation { get; set; }
        public virtual ICollection<GwchainManualOperation> GwchainManualOperation { get; set; }
    }
}
