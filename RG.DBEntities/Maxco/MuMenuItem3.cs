using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MuMenuItem3
    {
        public int Id { get; set; }
        public double? MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public double? MenuId { get; set; }
        public double? PageId { get; set; }
        public double? OrderId { get; set; }
        public double? LevelId { get; set; }
        public double? ParentMenuItemId { get; set; }
    }
}
