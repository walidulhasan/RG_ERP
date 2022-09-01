using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Results
    {
        public int Id { get; set; }
        public string ImageId { get; set; }
        public string Vender { get; set; }
        public string VenderType { get; set; }
        public string YarnColor { get; set; }
        public string MaterialCode { get; set; }
        public string VenderCode { get; set; }
    }
}
