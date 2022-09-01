using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class QRM_OrderSheetInterlinning
    {
        public int ID { get; set; }
        [ForeignKey("QRM_OrderSheetVersions")]
        public int VersionID { get; set; }
        public int RollWidthID { get; set; }
        public string RollWidth { get; set; }
        public int ConstructionID { get; set; }
        public string Construction { get; set; }
        public int TypeID { get; set; }
        public string Type { get; set; }
        public int SolubleTypeID { get; set; }
        public string SolubleType { get; set; }
        public double? OrderConsumption { get; set; }
        public double? CostingRate { get; set; }

        public virtual QRM_OrderSheetVersions QRM_OrderSheetVersions { get; set; }
    }
}
