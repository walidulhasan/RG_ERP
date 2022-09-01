using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonTemporaryReceiving
    {
        [Key]
        public int Trid { get; set; }
        public int ContractId { get; set; }
        public int Grid { get; set; }
        public string Trno { get; set; }
        public int InspectionStatus { get; set; }
        public long CompanyId { get; set; }
        public int Deleted { get; set; }
        public DateTime TempRecDate { get; set; }
        public int? UserId { get; set; }
        public double? CottonWeight { get; set; }
    }
}
