using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class CMBL_SubProgramProcess
    {
        [Key]
        public int SubProgram_ProcessID { get; set; }
        public string SubProgram_ProcessName { get; set; }
    }
}
