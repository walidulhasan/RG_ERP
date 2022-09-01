using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciShipmentDeclarationModels
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string Buyer { get; set; }
        public int OrderId { get; set; }
        public string Order { get; set; }
        public int ModelId { get; set; }
        public string Model { get; set; }
        public double QtyToShip { get; set; }
        public double ConsumedPpc { get; set; }
    }
}
