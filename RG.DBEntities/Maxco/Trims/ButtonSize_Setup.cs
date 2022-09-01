using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class ButtonSize_Setup
    {
        public ButtonSize_Setup()
        {
            ButtonSpecification = new HashSet<ButtonSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ButtonSpecification> ButtonSpecification { get; set; }
    }
}
