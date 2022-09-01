using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCartonTypeSetup
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public string Height { get; set; }
        public int? PackagingTypeId { get; set; }
    }
}
