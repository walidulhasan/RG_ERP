using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmOrderSheetVersionsActual
    {
        public int Id { get; set; }
        public int OrderSheetId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public string VersionNo { get; set; }
        public int? Status { get; set; }
        public string CostingInfoXml { get; set; }
    }
}
