using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmOrderSheetStyleActual
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int StyleId { get; set; }
        public int VersionId { get; set; }
    }
}
