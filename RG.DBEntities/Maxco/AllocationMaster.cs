using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class AllocationMaster
    {
        public AllocationMaster()
        {
            AllocationDetails = new HashSet<AllocationDetails>();
            AllocationRatios = new HashSet<AllocationRatios>();
        }
        [Key]
        public int AllocationId { get; set; }
        public int StyleId { get; set; }
        public DateTime? Date { get; set; }
        public string VersionNo { get; set; }
        public int? AssortmentColorsetId { get; set; }
        public int? ReqId { get; set; }
        public int? OrderId { get; set; }

       //   public virtual FsRequirementSheetMaster FsRequirementSheetMaster { get; set; }
        public virtual ICollection<AllocationDetails> AllocationDetails { get; set; }
        public virtual ICollection<AllocationRatios> AllocationRatios { get; set; }
    }
}
