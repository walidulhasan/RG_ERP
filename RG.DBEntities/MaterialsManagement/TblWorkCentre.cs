using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblWorkCentre
    {
        public decimal WcId { get; set; }
        public string WcDescrip { get; set; }
        public decimal ProcessVal { get; set; }
        public int? ProcessOrder { get; set; }
        public short? ProcessOrder2 { get; set; }
    }
}
