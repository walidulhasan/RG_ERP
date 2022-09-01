using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleMirmaterialManagement
    {
        public SampleMirmaterialManagement()
        {
            MaterialManagementJobItems = new HashSet<MaterialManagementJobItems>();
        }
        public int Id { get; set; }
        public int StyleId { get; set; }
        public byte? ProcurementSourceId { get; set; }
        public byte? Status { get; set; }
        public bool? IsGriege { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public int JobId { get; set; }
        public bool? IsWovenDenim { get; set; }
        public bool? IsOtherMaterial { get; set; }

        public virtual ICollection<MaterialManagementJobItems> MaterialManagementJobItems { get; set; }
    }
}
