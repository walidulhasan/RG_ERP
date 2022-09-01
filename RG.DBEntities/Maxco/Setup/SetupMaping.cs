using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SetupMaping
    {
        public int Id { get; set; }
        public short SetupDetailId { get; set; }
        public string Description { get; set; }
        public string FieldLength { get; set; }
        public bool? Validation { get; set; }
        public string TableFieldName { get; set; }
        public string PageFieldName { get; set; }
        public string Type { get; set; }
        public byte? DefaultValue { get; set; }

        public virtual SetupDetail SetupDetail { get; set; }
    }
}
