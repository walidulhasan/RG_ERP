using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class tbl_KnittingJobConfirmation//
    {
        [Key]
        public long ConfirmationID { get; set; }
        public long JobID { get; set; }
        public DateTime ConfirmationDate { get; set; }
    }
}
