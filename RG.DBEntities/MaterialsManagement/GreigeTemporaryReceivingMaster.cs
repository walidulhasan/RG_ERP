using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeTemporaryReceivingMaster
    {
        public GreigeTemporaryReceivingMaster()
        {
            GreigeTemporaryReceivingDetail = new HashSet<GreigeTemporaryReceivingDetail>();
        }
        [Key]

        public int Gtrmid { get; set; }
        public int Grid { get; set; }
        public string Tgrno { get; set; }
        public DateTime? TempRecDate { get; set; }
        public int Ykncid { get; set; }
        public int InspectedStatus { get; set; }

        public virtual ICollection<GreigeTemporaryReceivingDetail> GreigeTemporaryReceivingDetail { get; set; }
    }
}
