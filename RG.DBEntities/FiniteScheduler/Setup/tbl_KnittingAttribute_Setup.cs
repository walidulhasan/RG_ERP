using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class tbl_KnittingAttribute_Setup
    {
        public tbl_KnittingAttribute_Setup()
        {
            TblKnittingFabricProcessAssociation = new HashSet<tbl_KnittingFabricProcessAssociation>();
            tbl_KnittingLaboratoryInspection = new HashSet<tbl_KnittingLaboratoryInspection>();
        }
        [Key]
        public long ID { get; set; }
        public string ProcessName { get; set; }
        public string Description { get; set; }
        public double ToleranceStart { get; set; }
        public double ToleranceEnd { get; set; }

        public virtual ICollection<tbl_KnittingFabricProcessAssociation> TblKnittingFabricProcessAssociation { get; set; }
        public virtual ICollection<tbl_KnittingLaboratoryInspection> tbl_KnittingLaboratoryInspection { get; set; }
    }
}
