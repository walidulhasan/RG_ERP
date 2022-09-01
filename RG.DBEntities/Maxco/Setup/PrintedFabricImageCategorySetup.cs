using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PrintedFabricImageCategorySetup
    {
        public PrintedFabricImageCategorySetup()
        {
            PrintedFabricImagesSetup = new HashSet<PrintedFabricImagesSetup>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PrintedFabricImagesSetup> PrintedFabricImagesSetup { get; set; }
    }
}
