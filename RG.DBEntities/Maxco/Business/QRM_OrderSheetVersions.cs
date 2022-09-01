using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class QRM_OrderSheetVersions
    {
        public QRM_OrderSheetVersions()
        {
            QRM_OrderSheetFabrics = new HashSet<QRM_OrderSheetFabrics>();
            QRM_OrderSheetInterlinning = new HashSet<QRM_OrderSheetInterlinning>();
            QRM_OrderSheetStyle = new HashSet<QRM_OrderSheetStyle>();
            QRM_OrderSheetTrims = new HashSet<QRM_OrderSheetTrims>();
        }

        public int ID { get; set; }
        [ForeignKey("QRM_OrderSheet")]
        public int OrderSheetID { get; set; }       
        public DateTime? CreationDate { get; set; }
        public string VersionNo { get; set; }
        public int? Status { get; set; }
        public string CostingInfoXml { get; set; }
        public string CostingInfoJson { get; set; }
        
        public string Comments { get; set; }
        public virtual QRM_OrderSheet QRM_OrderSheet { get; set; }
        public virtual ICollection<QRM_OrderSheetFabrics> QRM_OrderSheetFabrics { get; set; }
        public virtual ICollection<QRM_OrderSheetInterlinning> QRM_OrderSheetInterlinning { get; set; }
        public virtual ICollection<QRM_OrderSheetStyle> QRM_OrderSheetStyle { get; set; }
        public virtual ICollection<QRM_OrderSheetTrims> QRM_OrderSheetTrims { get; set; }
    }
}
