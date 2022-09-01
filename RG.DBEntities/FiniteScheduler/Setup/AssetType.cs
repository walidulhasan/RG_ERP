using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class AssetType:DefaultTableProperties
    {
        public int AssetTypeID { get; set; }
        public string TypeName { get; set; }
        public string Code { get; set; }
        public int Serial { get; set; }
        public string Description { get; set; }
        
    }
}
