using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class ColorPalleteType_Setup
    {
        public ColorPalleteType_Setup()
        {
            SeriesColors = new HashSet<SeriesColors>();
        }

        public byte ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SeriesColors> SeriesColors { get; set; }
    }
}
