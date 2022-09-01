using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderCartonCodeSpecification
    {
        public int Id { get; set; }
        public int ShippmentPackingStyleId { get; set; }
        public bool IsAgainstShippmentPackingStyleId { get; set; }
        public bool IsAgainstRatio { get; set; }
        public bool IsAgainstSets { get; set; }
    }
}
