using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class AssetAttribute:DefaultTableProperties
    {
        public int AttributeID { get; set; }
        public string AttributeName { get; set; }
        public string AttributeShortName { get; set; }        
    }
}
