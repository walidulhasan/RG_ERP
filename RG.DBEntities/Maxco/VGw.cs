using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class VGw
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public string AssignedStyleNo { get; set; }
        public double FinalSmv { get; set; }
        public long GwchainId { get; set; }
    }
}
