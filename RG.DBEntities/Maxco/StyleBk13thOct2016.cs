using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StyleBk13thOct2016
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public byte? GarmentId { get; set; }
        public byte? Status { get; set; }
        public DateTime? SamplingDate { get; set; }
        public byte? CapturingStatus { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? SeriesId { get; set; }
        public long? ParentStyleId { get; set; }
        public byte? FabricCategoryId { get; set; }
        public int? ParentId { get; set; }
        public string OrderNo { get; set; }
        public int? CollectionId { get; set; }
        public int? UserId { get; set; }
        public int? ProcurementStatus { get; set; }
        public byte IsLocked { get; set; }
        public byte IsDummy { get; set; }
        public bool GrossStatus { get; set; }
        public DateTime? EstimatedDate { get; set; }
        public byte[] FrontImage { get; set; }
        public byte[] BackImage { get; set; }
        public string ReferenceNo { get; set; }
    }
}
