using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class Yarn_Contamination_Setup
    {
        [Key]
        public int Yarn_Id { get; set; }
        public string Yarn_ContType { get; set; }
    }
}
