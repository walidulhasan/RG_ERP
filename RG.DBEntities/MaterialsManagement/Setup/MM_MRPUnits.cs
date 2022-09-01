using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
   public partial class MM_MRPUnits 
    {
        public MM_MRPUnits()
        {
            MM_MRPItemUnits = new HashSet<MM_MRPItemUnits>();
        }
        [Key]
        public int MRPUnitsID { get; set; }
        public string UnitDesc { get; set; }
        public int UnitDatatype { get; set; }
        public virtual ICollection<MM_MRPItemUnits> MM_MRPItemUnits { get; set; }
    }
}
