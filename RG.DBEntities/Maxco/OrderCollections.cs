using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class OrderCollections
    {
        [Key]
        public int OrderCollectionId { get; set; }
        public string Name { get; set; }
    }
}
