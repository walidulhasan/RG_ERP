using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LdMaster
    {
        public int Id { get; set; }
        public int Ldid { get; set; }
        public string LabDipNo { get; set; }
        public string PantoneNo { get; set; }
        public string Hash { get; set; }
        public string Composition { get; set; }
        public int? FabricTypeId { get; set; }
        public int? FabricQualityId { get; set; }
        public string Gsm { get; set; }
        public int? Gsmba { get; set; }
        public DateTime? SubmitDate { get; set; }
        public int? SubmitYear { get; set; }
        public int? SubmitMonth { get; set; }
        public int? SubmitUser { get; set; }
        public int? StyleId { get; set; }
        public int? BuyerId { get; set; }
        public int? DyeingId { get; set; }
    }
}
