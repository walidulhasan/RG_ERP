using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ButtonMaterial_Setup
    {
        public ButtonMaterial_Setup()
        {
            ButtonImage_Setup = new HashSet<ButtonImage_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ButtonImage_Setup> ButtonImage_Setup { get; set; }
    }
}
