using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class JetClip
    {
        public int SelectedPackingAccessoriesId { get; set; }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? ImageId { get; set; }
        public int? AppearenceId { get; set; }
        public string PantoneNo { get; set; }
        public string Comments { get; set; }
        public int? NoOfPlacementPoint { get; set; }
    }
}
