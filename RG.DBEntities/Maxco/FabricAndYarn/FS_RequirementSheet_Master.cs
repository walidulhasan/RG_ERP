using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class FS_RequirementSheet_Master
    {
        public FS_RequirementSheet_Master()
        {
            //AllocationMaster = new HashSet<AllocationMaster>();
            //FsReceivingMaster = new HashSet<FsReceivingMaster>();
            //FsRequirementSheetOrderModels = new HashSet<FsRequirementSheetOrderModels>();
            //FsRequirementSheetSpecifications = new HashSet<FsRequirementSheetSpecifications>();
        }
        [Key]
        public int RequirementSheetID { get; set; }
        public string ReqNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime GenerationDate { get; set; }
        public int? UserID { get; set; }
        public int? OrderID { get; set; }
        public string OrderNo { get; set; }
        public int? StyleID { get; set; }
        public string StyleName { get; set; }
        public string CostingXml { get; set; }
        public long? RejectionSrsmasterID { get; set; }
        public string Comments { get; set; }
        public bool? IsSRS { get; set; }
        public int? ConsolidatedRejectedID { get; set; }
        public int? DayEndStatus { get; set; }
        public string CostingJson { get; set; }
        public ICollection<FS_RequirementSheet_Fabrics> FS_RequirementSheet_Fabrics { get; set; }
        public ICollection<FS_ColorSet> FS_ColorSet { get; set; }
        //public virtual ICollection<AllocationMaster> AllocationMaster { get; set; }
        //public virtual ICollection<FsReceivingMaster> FsReceivingMaster { get; set; }
        //public virtual ICollection<FsRequirementSheetOrderModels> FsRequirementSheetOrderModels { get; set; }
        //public virtual ICollection<FsRequirementSheetSpecifications> FsRequirementSheetSpecifications { get; set; }
    }
}
