using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class IC_ProcessSetup
    {
        [Key]
        public int ProcessID { get; set; }
        public string ProcessName { get; set; }
        public string ProcessDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
