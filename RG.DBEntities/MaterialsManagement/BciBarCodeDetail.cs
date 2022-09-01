using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciBarCodeDetail
    {
        public int Id { get; set; }
        public int BciCartonSetupDetailId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public int? ColorId { get; set; }

        public virtual BciCartonSetupDetail BciCartonSetupDetail { get; set; }
    }
}
