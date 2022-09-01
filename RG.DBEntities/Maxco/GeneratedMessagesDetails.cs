using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GeneratedMessagesDetails
    {
        public int MessageId { get; set; }
        public int Id { get; set; }
        public DateTime GenerationDate { get; set; }
        public string Justification { get; set; }
        public int? StyleId { get; set; }
        public string LotNo { get; set; }
        public int? JobNo { get; set; }
        public int? InitUserId { get; set; }
    }
}
