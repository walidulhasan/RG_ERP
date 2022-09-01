using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class ButtonTopType_Setup
    {
        public ButtonTopType_Setup()
        {
            ButtonPartHoleSetup = new HashSet<ButtonPartHole_Setup>();
        }

        public int ID{ get; set; }
        public string Description { get; set; }

        public virtual ICollection<ButtonPartHole_Setup> ButtonPartHoleSetup { get; set; }
    }
}
