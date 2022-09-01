using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class AssetSubType:DefaultTableProperties
    {
        public int AssetSubTypeID { get; set; }
        public int AssetTypeID { get; set; }
        public string SubTypeName { get; set; }
        public string Code { get; set; }
        public int Serial { get; set; }
        public string Description { get; set; }
    }
}
