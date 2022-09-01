using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class tbl_KnittingPickListDetail//
    {
        [Key]
        public long PickListDetailID { get; set; }
        [ForeignKey("tbl_KnittingPickListMaster")]
        public long PickListID { get; set; }
        public long AttributeInstanceID { get; set; }
        public double Quantity { get; set; }
        public int? UnitID { get; set; }
        public string BatchDescription { get; set; }

        public virtual tbl_KnittingPickListMaster tbl_KnittingPickListMaster { get; set; }
    }
}
