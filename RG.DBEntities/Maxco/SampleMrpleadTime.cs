using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleMrpleadTime
    {
        public int Id { get; set; }
        public int SampleSuperBomid { get; set; }
        public int SetUpTime { get; set; }
        public double? Var1 { get; set; }
        public double? Var2 { get; set; }
        public int? Capacity { get; set; }
        public int? VarId { get; set; }
        public int? PatternLimit { get; set; }
        public int? ColorLimit { get; set; }
        public int? NoOfMachines { get; set; }
    }
}
