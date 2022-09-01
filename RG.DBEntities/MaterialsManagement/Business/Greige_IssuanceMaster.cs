using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Greige_IssuanceMaster
    {
        public Greige_IssuanceMaster()
        {
            //Greige_IssuanceAgainstDyeingContract_Detail = new HashSet<Greige_IssuanceAgainstDyeingContract_Detail>();
        }
        [Key]
        public long GIID { get; set; }
        public DateTime? IssuanceDate { get; set; }
        public string IssuancePerson { get; set; }
        public string IssuanceNo { get; set; }
        public int? YKNCID { get; set; }
        public int? Status { get; set; }
        //public ICollection<Greige_IssuanceAgainstDyeingContract_Detail> Greige_IssuanceAgainstDyeingContract_Detail { get; set; }
    }
}
