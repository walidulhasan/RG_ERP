using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class VReqSheetTest
    {
        public int Id { get; set; }
        public string StyleName { get; set; }
        public string OrderNo { get; set; }
        public int Fid { get; set; }
        public int? FabricId { get; set; }
        public int? ColorSetId { get; set; }
        public int? ShellColorSetId { get; set; }
        public int? SizeSetId { get; set; }
        public int? TrimId { get; set; }
       
    }
}
