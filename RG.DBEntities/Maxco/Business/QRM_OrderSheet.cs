using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class QRM_OrderSheet
    {
        public QRM_OrderSheet()
        {
            QRM_OrderSheetVersions = new QRM_OrderSheetVersions();
        }
        public int ID { get; set; }
        public string SheetNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Status { get; set; }        
        public virtual QRM_OrderSheetVersions QRM_OrderSheetVersions { get; set; }
    }
}
