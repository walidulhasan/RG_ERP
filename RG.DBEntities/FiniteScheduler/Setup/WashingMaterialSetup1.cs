using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingMaterialSetup1
    {
        public int Id { get; set; }
        public int? MaterialTypeId { get; set; }
        public string Name { get; set; }
        public bool? IsSystemItem { get; set; }
        public bool Deleted { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
