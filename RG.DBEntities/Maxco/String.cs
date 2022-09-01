using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class String
    {
        public int Id { get; set; }
        public bool? IsStopperSelected { get; set; }
        public int? OrderId { get; set; }
        public int? AppearenceId { get; set; }
        public int? ItemSourceId { get; set; }
        public string PantoneNo { get; set; }
        public string Comments { get; set; }
        public int? NoOfPlacementPoints { get; set; }
        public int? MaterialId { get; set; }
        public int? SelectedPackingAccessoriesId { get; set; }
    }
}
