using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblLotweight
    {
        [Key]
        public long Irmlotwtid { get; set; }
        public long? Irmlotreqid { get; set; }
        public double? Irmlotfinalwt { get; set; }
        public DateTime? IrmlotwtDate { get; set; }
        public double? Irmlotdeliveredwt { get; set; }
        public string Irmlotreason { get; set; }
    }
}
