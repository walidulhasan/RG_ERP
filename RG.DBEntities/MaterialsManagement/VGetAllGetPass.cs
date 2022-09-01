using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class VGetAllGetPass
    {
        public byte CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long GatePassId { get; set; }
        public string Serial { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ApprovedDate { get; set; }
        public string ApprovedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public string VehicleNo { get; set; }
        public long? IssuedById { get; set; }
        public string IssuedBy { get; set; }
        public long? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string CustomerName { get; set; }
        public string IsExpired { get; set; }
        public short? ApprovedById { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public short? MarkedOutById { get; set; }
        public string MarkedOutBy { get; set; }
        public DateTime? MarkedOutOn { get; set; }
        public string Status { get; set; }
        public string CatName { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
