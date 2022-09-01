using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class AssetAttributeAssociation:DefaultTableProperties
    {
        public int AssociationID { get; set; }
        public int AssetSubTypeID { get; set; }
        public int AttributeID { get; set; }
        public int PrioritySerial { get; set; }
        public bool IsVisible { get; set; }
        public bool IsFilterable { get; set; }
        
    }
}
