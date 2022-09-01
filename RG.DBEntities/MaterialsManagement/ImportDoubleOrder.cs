using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class ImportDoubleOrder
    {
        [Key]
        public string Correctorder { get; set; }
        public long? Cartonno { get; set; }
        public string Model { get; set; }
        public string Order { get; set; }
        public long? Correctorderid { get; set; }
        public long? Orderid { get; set; }
    }
}
