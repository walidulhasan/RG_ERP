using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CuttingConfirmationMaster
    {
        public CuttingConfirmationMaster()
        {
            CuttingConfirmationDetail = new HashSet<CuttingConfirmationDetail>();
        }

        public int CuttingConfirmationMasterId { get; set; }
        public int? JobTicketId { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public int? UserId { get; set; }
        public string Comments { get; set; }
        public long? FabricDetailId { get; set; }
        public int DocumentType { get; set; }

        public virtual ICollection<CuttingConfirmationDetail> CuttingConfirmationDetail { get; set; }
    }
}
