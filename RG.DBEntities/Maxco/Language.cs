using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Language
    {
        public short Id { get; set; }
        public string Language1 { get; set; }
        public bool? IsActivated { get; set; }
    }
}
