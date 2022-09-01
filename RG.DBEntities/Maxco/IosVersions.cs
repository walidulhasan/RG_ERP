using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class IosVersions
    {
        public int Id { get; set; }
        public int IosId { get; set; }
        public int VersionNo { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string IosXml { get; set; }
        public bool? IsOld { get; set; }
    }
}
