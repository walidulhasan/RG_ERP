using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsInspectionApprovalDetail
    {
        public int InspectionApprovalDetailId { get; set; }
        public int InspectionApprovalId { get; set; }
        public string RollNo { get; set; }
        public int AttributeInstanceId { get; set; }
        public int Quantity { get; set; }
        public string FabricSkewing { get; set; }
        public string FabricRubbings { get; set; }
        public string FabricWashing { get; set; }
        public bool ColorShade { get; set; }
        public bool FabricTearing { get; set; }
        public double Gsm { get; set; }
        public double FinishWidth { get; set; }
        public string ShrinkageLen { get; set; }
        public string ShrinkageWidth { get; set; }
        public string Comments { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
