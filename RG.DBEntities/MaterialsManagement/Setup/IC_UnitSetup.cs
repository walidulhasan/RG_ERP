using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class IC_UnitSetup
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int ? DecimalPoint { get; set; }
    }
}
