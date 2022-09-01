using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_MaterialIssuanceMaster
    {
        public MM_MaterialIssuanceMaster()
        {
            MmReturnFromFloorMaster = new HashSet<MmReturnFromFloorMaster>();
        }
        [Key]
        public long MIID { get; set; }
        public DateTime? IssuanceDate { get; set; }
        public int OrderID { get; set; }
        public string IssuanceReceivingPerson { get; set; }
        public int ReasonID { get; set; }
        public int? CostCenterID { get; set; }
        public int? ModelID { get; set; }
        public long IssuanceNo { get; set; }
        public int? LocationID { get; set; }
        public string ChallanNo { get; set; }
        public long? CompanyID { get; set; }
        public long? BusinessID { get; set; }

        public virtual ICollection<MmReturnFromFloorMaster> MmReturnFromFloorMaster { get; set; }
    }
}
