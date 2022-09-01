using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo
{
    public class AssetWiseAttributeValuesVM
    {
        public long AssociationValueID { get; set; }
        public int AssetID { get; set; }
        public int AssociationID { get; set; }
        public int AssetSubTypeID { get; set; }
        public string AssetSubTypeName { get; set; }
        public int AttributeID { get; set; }
        public string AttributeName { get; set; }
        public int PrioritySerial { get; set; }
        public bool IsVisible { get; set; }
        public bool IsFilterable { get; set; }
        public int? ValueID { get; set; }
        public string ValueDescription { get; set; }
    }
}
