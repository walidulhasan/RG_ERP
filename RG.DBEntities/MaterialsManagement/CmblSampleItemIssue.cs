using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblSampleItemIssue
    {
        [Key]
        public int SampleItemIssueId { get; set; }
        public int SampleIssueId { get; set; }
        public long SampleItemId { get; set; }
        public decimal IssuedQuantity { get; set; }
    }
}
