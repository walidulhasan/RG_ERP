using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.AssetAttributeAssociation.Queries.RequestResponseModel
{
    public class AssetSubTypeWiseAttributesRM
    {        
        public int AssociationID { get; set; }
        public int AssetSubTypeID { get; set; }
        public string AssetSubTypeName { get; set; }
        public int AttributeID { get; set; }
        public string AttributeName { get; set; }
        public int PrioritySerial { get; set; }
        public bool IsVisible { get; set; }
        public bool IsFilterable { get; set; }       
        
    }
}
