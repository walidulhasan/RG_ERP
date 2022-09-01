using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class AssetAttributeAssociationValue:DefaultTableProperties
    {
        public long AssociationValueID { get; set; }
        public int AssetID { get; set; }
        public int AssociationID { get; set; }
        public int? ValueID { get; set; }
        public string ValueDescription { get; set; }
        
    }
}
