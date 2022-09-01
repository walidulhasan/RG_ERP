using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcCbtbAmendmentDetail
    {
        public int Id { get; set; }
        public int Amddid { get; set; }
        public int Amdtid { get; set; }
        public string Ovalue { get; set; }
        public string Nvalue { get; set; }
        public string Otext { get; set; }
        public string Ntext { get; set; }
        public int Amdmaster { get; set; }
    }
}
