using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class AssetAssignedType:DefaultTableProperties
    {
        public int AssignedTypeNameID { get; set; }
        public string AssignedTypeName { get; set; }
        public string AssignedTypeCode { get; set; }
    }
}
