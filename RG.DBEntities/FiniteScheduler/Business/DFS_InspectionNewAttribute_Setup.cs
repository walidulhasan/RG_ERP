using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class DFS_InspectionNewAttribute_Setup
    {
        public long ID { get; set; }
        public long? OldDCGAttributeInstanceID { get; set; }
        public long? NewDCGAttributeInstanceID { get; set; }
        public long? RollID { get; set; }
        public string RollNo { get; set; }
        public long? YKNCID { get; set; }
        public long? MachineID { get; set; }
        public int? FinishedGSM { get; set; }
        public double? FinishedWidth { get; set; }
        public double? FinishedWeight { get; set; }
    }
}
