using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class HeadPin
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? FinishId { get; set; }
        public string Color { get; set; }
        public string Comments { get; set; }
        public int? ImageId { get; set; }
        public int? SelectedPackingAccessoriesId { get; set; }
    }
}
