using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnGrossMaster
    {
        public int Id { get; set; }
        public string YarnGrossCode { get; set; }
        public string YarnGrossDetail { get; set; }
        public DateTime? GenerationDate { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
