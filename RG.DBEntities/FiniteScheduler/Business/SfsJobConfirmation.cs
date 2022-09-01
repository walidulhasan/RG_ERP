using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsJobConfirmation
    {
        public SfsJobConfirmation()
        {
            SfsConfirmationNauditAssociation = new HashSet<SfsConfirmationNauditAssociation>();
        }

        public long ConfirmationId { get; set; }
        public long JobId { get; set; }
        public long StyleId { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public int Deleted { get; set; }
        public int IssuanceStatus { get; set; }
        public string IsBarCode { get; set; }
        public bool? SendToRework { get; set; }
        public string Remarks { get; set; }

        public virtual SfsJob Job { get; set; }
        public virtual ICollection<SfsConfirmationNauditAssociation> SfsConfirmationNauditAssociation { get; set; }
    }
}
