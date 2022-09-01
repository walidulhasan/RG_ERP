using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsReceivingMaster
    {
        public FsReceivingMaster()
        {
            //FsReceivingLots = new HashSet<FsReceivingLots>();
            //FsReceivingVariations = new HashSet<FsReceivingVariations>();
        }

        public int Id { get; set; }
        public int ReqSheetId { get; set; }
        public string MaxcoCode { get; set; }
        public int VersionNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Dcno { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? UserId { get; set; }
        public string RecSheetNo { get; set; }
        public string ClientName { get; set; }

        //public virtual FsRequirementSheetMaster ReqSheet { get; set; }
        //public virtual ICollection<FsReceivingLots> FsReceivingLots { get; set; }
        //public virtual ICollection<FsReceivingVariations> FsReceivingVariations { get; set; }
    }
}
