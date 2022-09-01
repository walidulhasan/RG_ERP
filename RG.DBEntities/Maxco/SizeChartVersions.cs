using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SizeChartVersions
    {
        public SizeChartVersions()
        {
            SizeChartSpecification = new HashSet<SizeChartSpecification>();
            SizeChartToleranceComments = new HashSet<SizeChartToleranceComments>();
        }

        public int Id { get; set; }
        public byte VersionNo { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public int SelectedElementId { get; set; }

        public virtual SelectedElement SelectedElement { get; set; }
        public virtual ICollection<SizeChartSpecification> SizeChartSpecification { get; set; }
        public virtual ICollection<SizeChartToleranceComments> SizeChartToleranceComments { get; set; }
    }
}
