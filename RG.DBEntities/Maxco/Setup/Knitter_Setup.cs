using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class Knitter_Setup
    {
        public int ID { get; set; }
        public string KnitterName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public int? COAID { get; set; }
    }
}
