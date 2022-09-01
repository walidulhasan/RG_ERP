using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class BuildingType: DefaultTableProperties
    {
        public int ID { get; set; }
        public string BuildingTypeName { get; set; }
    }
}
