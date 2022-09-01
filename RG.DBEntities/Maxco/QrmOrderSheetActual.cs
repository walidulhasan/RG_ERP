using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmOrderSheetActual
    {
        public int Id { get; set; }
        public string SheetNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public byte? Status { get; set; }
        public int? CreatedBy { get; set; }
    }
}
