using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ModelClassificationSetup
    {
        public ModelClassificationSetup()
        {
            OrderSelectedStyle = new HashSet<OrderSelectedStyle>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderSelectedStyle> OrderSelectedStyle { get; set; }
    }
}
