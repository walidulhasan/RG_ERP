using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public partial class Dyed_TemporaryReceivingMaster
    {
        [Key]
        public long DTRID { get; set; }
        public int DCID { get; set; }
        public string TGRNo { get; set; }
        public DateTime? TempRecDate { get; set; }
        public int InspectedStatus { get; set; }
        public string PantoneNo { get; set; }
        public byte? IsPO { get; set; }
        public int? GRID { get; set; }
        public bool? IsDependent { get; set; }
    }
}
