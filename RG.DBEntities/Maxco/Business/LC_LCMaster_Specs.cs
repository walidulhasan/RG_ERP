using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class LC_LCMaster_Specs
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public int? LCTypeID { get; set; }
        public int? TypeID { get; set; }
        public QRM_LCOrderAssociation QRM_LCOrderAssociation { get; set; }
    }
}
