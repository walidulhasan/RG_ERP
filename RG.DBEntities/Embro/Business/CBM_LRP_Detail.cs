using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class CBM_LRP_Detail
    {
        [ForeignKey("CBM_LRP")]
        public decimal LRPID { get; set; }
        [ForeignKey("Rentals")]
        public int RentalID { get; set; }

        public virtual CBM_LRP CBM_LRP { get; set; }
        public virtual Rentals Rentals { get; set; }
    }
}
