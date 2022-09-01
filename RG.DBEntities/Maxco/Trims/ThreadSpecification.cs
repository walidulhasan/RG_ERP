using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ThreadSpecification 
    {
        public ThreadSpecification()
        {
            ThreadColor = new HashSet<ThreadColor>();
           // ThreadColor2 = new HashSet<ThreadColor2>();
            ThreadPlacementInstruction = new HashSet<ThreadPlacementInstruction>();
        }

        public int ID { get; set; }
        public int? SelectedPurposeID { get; set; }
        public int? ObjectId { get; set; }
        public int? TrimID { get; set; }
        public int MaterialID { get; set; }
        public int CountID { get; set; }
        public double? Consumption { get; set; }
        public int? TrimMeasurementScaleID { get; set; }
        public long SelectedTrimID { get; set; }
        public int VersionNo { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }
        public int? NoOfPlies { get; set; }
        public int? ProcurementSourceID { get; set; }
        public int? InsertionID { get; set; }
        public double? ThreadConsumption { get; set; }
        public int? ProcurementUnitID { get; set; }
        public int? TrimStatus { get; set; }

        public virtual ICollection<ThreadColor> ThreadColor { get; set; }
      //  public virtual ICollection<ThreadColor2> ThreadColor2 { get; set; }
        public virtual ICollection<ThreadPlacementInstruction> ThreadPlacementInstruction { get; set; }
    }
}
