using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class Location
    {
        public Location()
        {
            CostCenterLocation = new HashSet<CostCenterLocation>();
        }
        [Key]
        [ForeignKey("BasicCOA")]
        public decimal SrNum { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string PlotNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Fax { get; set; }
        public string LocationInitials { get; set; }

        public virtual BasicCOA BasicCOA { get; set; }
        public virtual ICollection<CostCenterLocation> CostCenterLocation { get; set; }
    }
}
