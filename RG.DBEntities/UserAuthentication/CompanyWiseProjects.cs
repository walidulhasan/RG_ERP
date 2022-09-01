using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.UserAuthentication
{
    public class CompanyWiseProjects
    {
        [Key]
        public int CompanyWiseProjectID { get; set; }

        public int CompanyID { get; set; }
        public int ProjectID { get; set; }

        [Column(Order = 95)]
        public bool? IsActive { get; set; }

        [Column(Order = 96)]
        public bool? IsRemoved { get; set; }

        [Column(Order = 97)]
        public DateTime? CreatedDate { get; set; }

        [Column(Order = 98)]
        public int? CreatedBy { get; set; }

        [Column(Order = 99)]
        public DateTime? LastModifiedDate { get; set; }

        [Column(Order = 100)]
        public int? LastModifiedBy { get; set; }
    }
}