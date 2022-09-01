using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class EmailTrim
    {
        public int Id { get; set; }
        public int? TrimId { get; set; }
        public int? StyleId { get; set; }
        public string Filename { get; set; }
        public DateTime? CreateDate { get; set; }
        public string GroupFile { get; set; }
        public string XmlFile { get; set; }
    }
}
