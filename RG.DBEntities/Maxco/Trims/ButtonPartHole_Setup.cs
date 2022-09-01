using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class ButtonPartHole_Setup
    {
        public ButtonPartHole_Setup()
        {
            ButtonSpecification = new HashSet<ButtonSpecification>();
        }

        public int ID { get; set; }
        public int TopTypeID { get; set; }
        public string Description { get; set; }

        public virtual ButtonTopType_Setup TopType { get; set; }
        public virtual ICollection<ButtonSpecification> ButtonSpecification { get; set; }
    }
}
