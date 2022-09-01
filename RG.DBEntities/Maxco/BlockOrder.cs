using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class BlockOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BuyerId { get; set; }
        public int GarmentId { get; set; }
        public int NumberOfMonths { get; set; }
        public short? Status { get; set; }
        public bool? IsBuyerRequest { get; set; }
        public string Comments { get; set; }
    }
}
