using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StyleComments
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public string Comments { get; set; }
    }
}
