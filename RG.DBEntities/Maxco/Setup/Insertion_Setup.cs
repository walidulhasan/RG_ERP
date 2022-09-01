using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class Insertion_Setup
    {
        public Insertion_Setup()
        {
            //ElementInsertionSetup = new HashSet<ElementInsertionSetup>();
            //TrimInsertionSetup = new HashSet<TrimInsertionSetup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public bool? IsRGD { get; set; }

       // public virtual ICollection<ElementInsertionSetup> ElementInsertionSetup { get; set; }
       // public virtual ICollection<TrimInsertionSetup> TrimInsertionSetup { get; set; }
    }
}
