using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderPackingAssortmentCombination
    {
        public byte Id { get; set; }
        public byte? PackingTypeId { get; set; }
        public byte? PackingAssortmentInfoTypeId { get; set; }
        public string Option { get; set; }
        public string CombinationName { get; set; }
    }
}
