using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class YarnRackSetup:DefaultTableProperties
    {
        public YarnRackSetup()
        {
            YarnSubRackSetup = new List<YarnSubRackSetup>();
        }
        public int RackID { get; set; }
        public string RackName { get; set; }
        public string RackShortName { get; set; }
        public int RackSerial { get; set; }
        public int BuildingFloorID { get; set; }
        public string RackDescription { get; set; }
        public int RackRow { get; set; }
        public int RackColumn { get; set; }
        public virtual List<YarnSubRackSetup> YarnSubRackSetup { get; set; }
        
    }
}
