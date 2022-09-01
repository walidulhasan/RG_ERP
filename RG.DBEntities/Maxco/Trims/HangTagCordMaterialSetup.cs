using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangTagCordMaterialSetup
    {
        public HangTagCordMaterialSetup()
        {
          //  HangTagSpecification = new HashSet<HangTagSpecification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

       // public virtual ICollection<HangTagSpecification> HangTagSpecification { get; set; }
    }
}
