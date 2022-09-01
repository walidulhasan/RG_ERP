using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TagPin
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? AppearenceId { get; set; }
        public int? AttachmentMethodId { get; set; }
        public int? ItemSourceId { get; set; }
        public string Comments { get; set; }
        public int? SelectedPackingAccessoriesId { get; set; }
    }
}
