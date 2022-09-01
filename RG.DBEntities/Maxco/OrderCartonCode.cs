using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderCartonCode
    {
        public int Id { get; set; }
        public int CartonCodeSpecificationId { get; set; }
        public string CartonCode { get; set; }
        public int? ColorSetId { get; set; }
        public int? SizeSetId { get; set; }
    }
}
