using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PrintedFabricImagesSetup
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }

        public virtual PrintedFabricImageCategorySetup Category { get; set; }
    }
}
