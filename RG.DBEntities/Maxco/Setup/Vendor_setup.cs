using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class Vendor_setup
    {
        public Vendor_setup()
        {
            //MaterialOperationVendor = new HashSet<MaterialOperationVendor>();
            //TrimPomaster = new HashSet<TrimPomaster>();
        }
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public int? TrimID { get; set; }
        public int? SampleSuperBOMID { get; set; }

        //public virtual ICollection<MaterialOperationVendor> MaterialOperationVendor { get; set; }
        //public virtual ICollection<TrimPomaster> TrimPomaster { get; set; }
    }
}
