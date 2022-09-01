using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnGrossMasterVersion
    {
        public int Id { get; set; }
        public int GrossId { get; set; }
        public string YarnGrossCode { get; set; }
        public string YarnGrossDetail { get; set; }
        public DateTime? GenerationDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Remarks { get; set; }
    }
}
