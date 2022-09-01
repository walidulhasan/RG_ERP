using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Dyed_InspectionMaster
    {
        [Key]
        public long DIID { get; set; }
        public long DTRID { get; set; }
        public string DINSNO { get; set; }
        public DateTime InspectionDate { get; set; }
        public int DCID { get; set; }
        public string LotNo { get; set; }
        public int? GRNStatus { get; set; }
        public int? FabricCategoryID { get; set; }
        public long? UserID { get; set; }
        public string Comments { get; set; }
        public int? InspectionType { get; set; }
    }
}
