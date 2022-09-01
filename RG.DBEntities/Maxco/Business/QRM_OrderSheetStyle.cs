using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class QRM_OrderSheetStyle
    {
        public int ID { get; set; }
        public long OrderID { get; set; }
        public long StyleID { get; set; }
        [ForeignKey("QRM_OrderSheetVersions")]
        public int VersionID { get; set; }

        public virtual QRM_OrderSheetVersions QRM_OrderSheetVersions { get; set; }
    }
}
