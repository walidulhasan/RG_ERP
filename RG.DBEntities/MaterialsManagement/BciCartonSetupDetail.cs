using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCartonSetupDetail
    {
        public BciCartonSetupDetail()
        {
            BciBarCodeDetail = new HashSet<BciBarCodeDetail>();
        }

        public int Id { get; set; }
        public int BciCartonSetupMasterId { get; set; }
        public string BarCode { get; set; }
        public string Model { get; set; }
        public double? ModelExportPrice { get; set; }
        public string Color { get; set; }
        public int? Bcoccurence { get; set; }

        public virtual BciCartonSetupMaster BciCartonSetupMaster { get; set; }
        public virtual ICollection<BciBarCodeDetail> BciBarCodeDetail { get; set; }
    }
}
