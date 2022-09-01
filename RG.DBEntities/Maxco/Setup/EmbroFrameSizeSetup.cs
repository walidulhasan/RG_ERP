using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class EmbroFrameSizeSetup
    {
        public int Id { get; set; }
        public string FrameName { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
    }
}
