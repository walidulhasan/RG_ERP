using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TempTable2
    {
        public int Id { get; set; }
        public int? Msomid { get; set; }
        public string ReferenceNo { get; set; }
        public string Remarks { get; set; }
        public DateTime? Msodate { get; set; }
        public int? TrimInventoryId { get; set; }
        public string Mname { get; set; }
        public int? MrpitemCode { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string MavalueDescription { get; set; }
        public int? MavalueId { get; set; }
        public byte[] Picture { get; set; }
    }
}
