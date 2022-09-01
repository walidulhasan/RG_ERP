using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class ResourceState
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateDescription { get; set; }
    }
}
