using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SizeChartJustificationSetup
    {
        public SizeChartJustificationSetup()
        {
            SizeChartJustification = new HashSet<SizeChartJustification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SizeChartJustification> SizeChartJustification { get; set; }
    }
}
