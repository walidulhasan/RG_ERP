using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TrimStatusSetup
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string StatusDescription { get; set; }
    }
}
