using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
   public class Yarn_ProgramType_Setup
    {
        [Key]
        public int ProgramTypeID { get; set; }
        public string ProgramType { get; set; }
    }
}
