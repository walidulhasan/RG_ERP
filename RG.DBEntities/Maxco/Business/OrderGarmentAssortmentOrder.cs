using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
   public class OrderGarmentAssortmentOrder
    {
        public int ID { get; set; }
        public int? OrderStyleID { get; set; }
        public int? FabricID { get; set; }
        public int SizeSetID { get; set; }
        public int ColorSetID { get; set; }
        public bool? IsMain { get; set; }
        public int? NumberOfGarments { get; set; }
        public int? SuperBOMID { get; set; }
        public int GrossStatus { get; set; }
        public string VariationColor { get; set; }
        public int? ShippmentPackingStyleID { get; set; }
        public int? PackingTypeID { get; set; }
        public int? ShippmentID { get; set; }
        public int? value { get; set; }
    }
}
