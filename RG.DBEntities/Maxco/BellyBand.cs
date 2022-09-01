using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class BellyBand
    {
        public int Id { get; set; }
        public int? PrintImageId { get; set; }
        public long MaterialId { get; set; }
        public long ItemSourceId { get; set; }
        public int NumberPerGarment { get; set; }
        public string Comments { get; set; }
        public long OrderId { get; set; }
        public long? SelectedPackingAccessoriesId { get; set; }
    }
}
