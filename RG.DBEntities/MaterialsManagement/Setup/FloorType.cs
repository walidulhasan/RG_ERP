using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class FloorType:DefaultTableProperties
    {
        public int FloorTypeID { get; set; }
        public string FloorTypeName { get; set; }
        public string FloorTypeDescription { get; set; }
    }
}
