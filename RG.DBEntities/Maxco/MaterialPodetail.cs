using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialPodetail
    {  [Key]
        public int Mpdid { get; set; }
        public int Mpmid { get; set; }
        public int MrpitemCode { get; set; }
        public int AttributeInstanceId { get; set; }
        public int? ObjectId { get; set; }
        public int? SuperBomid { get; set; }
        public double Rate { get; set; }
        public double Gst { get; set; }
    }
}
