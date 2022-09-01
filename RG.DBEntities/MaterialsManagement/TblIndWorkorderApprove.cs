using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblIndWorkorderApprove
    {
        public long Id { get; set; }
        public long? WorkorderNo { get; set; }
        public long? Status { get; set; }
        public long? UserId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
