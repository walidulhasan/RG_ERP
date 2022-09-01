using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class YarnSubRackSetup:DefaultTableProperties
    {
        public int SubRackID { get; set; }

        [ForeignKey("YarnRackSetup")]
        public int RackID { get; set; }
        public string SubRackName { get; set; }
        public string SubRackShortName { get; set; }
        public int SubRackSerial { get; set; }
        public int SubRackRowSerial { get; set; }
        public int SubRackColumnSerial { get; set; }
        public string SubRackDescription { get; set; }
        public decimal StorageLimit { get; set; }
        //nav
        public virtual YarnRackSetup YarnRackSetup { get; set; }
    }
}
