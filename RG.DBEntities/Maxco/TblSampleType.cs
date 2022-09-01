using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TblSampleType
    {
        public int Id { get; set; }
        public long Sampletypeid { get; set; }
        public string SampleType { get; set; }
        public long? Status { get; set; }
    }
}
