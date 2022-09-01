using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class QRM_LCOrderAssociation
    {
        public int ID { get; set; }
        public long? OrderID { get; set; }
        [ForeignKey("LC_LCMaster_Specs")]
        public long? LCMasterID { get; set; }
        public int Flag { get; set; }
        public LC_LCMaster_Specs LC_LCMaster_Specs { get; set; }
    }
}
