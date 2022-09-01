using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class EmailStyleElement
    {
        public int Id { get; set; }
        public int ElementId { get; set; }
        public int StyleId { get; set; }
        public string Filename { get; set; }
    }
}
