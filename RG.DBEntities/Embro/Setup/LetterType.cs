using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Setup
{
    public partial class LetterType
    {
        public int ID { get; set; }
        public int LetterTypeId { get; set; }
        public string LetterTypeDescription { get; set; }
    }
}
