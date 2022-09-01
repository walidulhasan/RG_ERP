using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ThreadPurpose_Setup
    {
        public ThreadPurpose_Setup()
        {
            SelectedThreadPurpose = new HashSet<SelectedThreadPurpose>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public bool DisplayInList { get; set; }

        public virtual ICollection<SelectedThreadPurpose> SelectedThreadPurpose { get; set; }
    }
}
