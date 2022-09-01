using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.SubTypeAttributeAssociations.Queries.RequestResponseModel
{
    public class SubTypeAttributeAssociationRM
    {
        public int AttributeID { get; set; }
        public string AttributeName { get; set; }
        public int AssociationID { get; set; }
        public int PrioritySerial { get; set; }
        public bool IsVisible { get; set; }
        public bool IsFilterable { get; set; }
    }
}
