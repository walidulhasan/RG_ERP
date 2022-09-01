using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class Trim_Setup
    {
        public Trim_Setup()
        {
            SelectedTrim = new HashSet<SelectedTrim>();
            TrimCodeSetup = new HashSet<TrimCodeSetup>();
            TrimInsertion_Setup = new HashSet<TrimInsertion_Setup>();
            TrimPlacementInstruction_Setup = new HashSet<TrimPlacementInstruction_Setup>();
            TrimWastage_Setup = new HashSet<TrimWastage_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public byte TrimCategoryID { get; set; }
        public string HomePage { get; set; }
        public bool? IsDisplay { get; set; }
        public string DisplayPage { get; set; }
        public int? MRPItemCode { get; set; }
        public bool? IsGreigeTrim { get; set; }
        public bool? IsGenericTrim { get; set; }
        public int? TrimIndex { get; set; }
        public string Abbrievation { get; set; }
        public int? TrimTypeID { get; set; }
        public string nHomePage { get; set; }
        public string nDisplayPage { get; set; }

        public virtual TrimCategory_Setup TrimCategory { get; set; }
        public virtual ICollection<SelectedTrim> SelectedTrim { get; set; }
        public virtual ICollection<TrimCodeSetup> TrimCodeSetup { get; set; }
        public virtual ICollection<TrimInsertion_Setup> TrimInsertion_Setup { get; set; }
        public virtual ICollection<TrimPlacementInstruction_Setup> TrimPlacementInstruction_Setup { get; set; }
        public virtual ICollection<TrimWastage_Setup> TrimWastage_Setup { get; set; }
    }
}
