using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class PrintSizes
    {
        public int ID { get; set; }
        [ForeignKey("PrintingSpecification")]
        public int ObjectID { get; set; }
        public int SelectedSizeRangeID { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }

        public virtual PrintingSpecification PrintingSpecification { get; set; }
    }
}
