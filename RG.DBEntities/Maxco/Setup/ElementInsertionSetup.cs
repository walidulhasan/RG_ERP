using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ElementInsertionSetup
    {
        public int Id { get; set; }
        public int ElementId { get; set; }
        public byte InsertionId { get; set; }

        public virtual Insertion_Setup Insertion { get; set; }
    }
}
