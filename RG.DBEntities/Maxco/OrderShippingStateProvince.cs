using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderShippingStateProvince
    {
        public short Id { get; set; }
        public string Description { get; set; }
        public byte? CountryId { get; set; }
    }
}
