using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetAttributeAssociations.Queries.RequestResponseModel
{
    public class FilterableAttributesRM
    {
        public int AttributeID { get; set; }
        public string AttributeName { get; set; }
        public int PrioritySerial { get; set; }       
    }
}
