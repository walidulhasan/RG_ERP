using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTracking
    {
        public int Id { get; set; }
        public string ProcessOrderNo { get; set; }
        public string PreparedBy { get; set; }
        public string ReceivedBy { get; set; }
        public string InitiatingDate { get; set; }
        public string ReqXml { get; set; }
        public int? BuyerId { get; set; }
    }
}
