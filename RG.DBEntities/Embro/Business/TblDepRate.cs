using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class TblDepRate
    {
        public int? AssetCoaid { get; set; }
        public int? Parentid { get; set; }
        public double? DepRate { get; set; }
        public int? Companyid { get; set; }
    }
}
