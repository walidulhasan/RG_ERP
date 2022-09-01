using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MasterBarCodeView
    {
        [Key]
        public string OrderNo { get; set; }
        public string StyleCode { get; set; }
        public string AssortementCode { get; set; }
        public string ColorCode { get; set; }
        public string SizeDesc { get; set; }
        public string MasterBarCode { get; set; }
        public string SingleBarCode { get; set; }
    }
}
