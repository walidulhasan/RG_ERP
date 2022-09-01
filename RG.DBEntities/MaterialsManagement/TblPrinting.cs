using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblPrinting
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public long? PrintId { get; set; }
        public decimal? ChemicalCost { get; set; }
        public decimal? Smv { get; set; }
        public int? Manpower { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? UserId { get; set; }
    }
}
