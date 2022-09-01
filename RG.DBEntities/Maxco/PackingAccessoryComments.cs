using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PackingAccessoryComments
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public string Comments { get; set; }
    }
}
