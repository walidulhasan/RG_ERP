using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class YsMvMasterreportView
    {
        public int Id { get; set; }
        public int YmvId { get; set; }
        public string YmvUser { get; set; }
        public DateTime? YmvDate { get; set; }
        public string YmvDescription { get; set; }
        public string YmvView { get; set; }
    }
}
