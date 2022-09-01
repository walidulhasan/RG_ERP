using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MaReceiving
    {
        public int Id { get; set; }
        public int MasubmissionId { get; set; }
        public DateTime ReceivingDate { get; set; }
        public byte StatusId { get; set; }
        public string Comments { get; set; }
    }
}
