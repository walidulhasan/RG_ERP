using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class tbl_KnittingJobs
    {
        [Key]
        public long JobID { get; set; }
        public long YarnKnittingContractID { get; set; }
        public double Quantity { get; set; }
        public int JobStatusID { get; set; }
        public string JobName { get; set; }
        public long? MachineID { get; set; }
        public long? StartingDayMinuteID { get; set; }
        public long? EndingDayMinuteID { get; set; }
        public DateTime? CreationDate { get; set; }
        public double? ProcessRate { get; set; }
        public bool? IsOld { get; set; }
    }
}
