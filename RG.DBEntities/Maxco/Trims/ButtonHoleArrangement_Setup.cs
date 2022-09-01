using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ButtonHoleArrangement_Setup
    {
        public ButtonHoleArrangement_Setup()
        {
            ButtonSpecification = new HashSet<ButtonSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ButtonSpecification> ButtonSpecification { get; set; }
    }
}
