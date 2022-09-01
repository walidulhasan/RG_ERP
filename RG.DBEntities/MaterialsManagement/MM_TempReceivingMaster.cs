using RG.DBEntities.MaterialsManagement.GateReceiving;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_TempReceivingMaster
    {
        public MM_TempReceivingMaster()
        {
             MM_MaterialInspection_Master = new HashSet<MM_MaterialInspection_Master>();
        }
        [Key]
        public long MTRMID { get; set; }
        [ForeignKey("MM_GateReceiving")]
        public int GRID { get; set; }
        public string TGRNo { get; set; }
        public DateTime? TempRecDate { get; set; }
        public int POID { get; set; }
        public int? InspectedStatus { get; set; }
        public int flag { get; set; }
        public long? CompanyID { get; set; }
        public long? BusinessID { get; set; }
        public virtual MM_GateReceiving MM_GateReceiving { get; set; }
        public virtual ICollection<MM_MaterialInspection_Master> MM_MaterialInspection_Master { get; set; }
    }
}
