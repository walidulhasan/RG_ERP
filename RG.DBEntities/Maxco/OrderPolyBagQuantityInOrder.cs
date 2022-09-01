using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderPolyBagQuantityInOrder
    {
        public int Id { get; set; }
        public int PolyBagSpecsId { get; set; }
        public int StyleId { get; set; }
        public int? SizeSetId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Flap { get; set; }
    }
}
