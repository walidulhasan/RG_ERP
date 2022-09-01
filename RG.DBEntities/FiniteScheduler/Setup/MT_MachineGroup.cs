using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class MT_MachineGroup:DefaultTableProperties
    {
        public int ID { get; set; }
        public string MachineGroup { get; set; }
    }
}
