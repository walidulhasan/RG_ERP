using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
   public partial class ModelCostAllowances
    {
        public int ID { get; set; }
        [ForeignKey("ModelCosting")]
        public int VersionID { get; set; }
        public int AllowanceID { get; set; }
        public int AllowancePer { get; set; }
        public double AllowanceCost { get; set; }

        public virtual ModelCosting ModelCosting { get; set; }
    }
}
