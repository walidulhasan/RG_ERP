using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblSample
    {
        [Key]
        public long SampleId { get; set; }
        public long SampleNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ApproxDeliveryDate { get; set; }
        public int UserId { get; set; }
        public int? SupplierId { get; set; }
        public string SampleComments { get; set; }
        public int? CompanyId { get; set; }
        public int? ApprovedBy { get; set; }
        public string MainComments { get; set; }
        public decimal? TotalValue { get; set; }
        public int? LocationSelStatus { get; set; }
        public int? DateSelStatus { get; set; }
        public int? PriceSelStatus { get; set; }
        public int SampleStatus { get; set; }
    }
}
