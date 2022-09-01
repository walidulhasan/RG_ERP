using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimReceiptDetail
    {
        public int Id { get; set; }
        public int TrimReceiptDetailId { get; set; }
        public int Mrmid { get; set; }
        public int TrimInventoryId { get; set; }
    }
}
