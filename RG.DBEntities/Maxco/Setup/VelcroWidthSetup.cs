using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class VelcroWidthSetup
    {
        public VelcroWidthSetup()
        {
            VelcroSpecification = new HashSet<VelcroSpecification>();
        }

        public byte Id { get; set; }
        public double Description { get; set; }
        public byte MeasurementScaleId { get; set; }

        public virtual ICollection<VelcroSpecification> VelcroSpecification { get; set; }
    }
}
