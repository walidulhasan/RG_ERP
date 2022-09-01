using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ChainMachineAttachment
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public string Placement { get; set; }
        public string Size { get; set; }
        public int TotalNo { get; set; }
        public string AttachmentType { get; set; }
    }
}
