using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Ddsupplier
    {
        public Ddsupplier()
        {
            DdblockedSupplier = new HashSet<DdblockedSupplier>();
            DdsupplierDomain = new HashSet<DdsupplierDomain>();
            DdsupplierItem = new HashSet<DdsupplierItem>();
        }

        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Ntn { get; set; }
        public string ContactName1 { get; set; }
        public string Designation1 { get; set; }
        public string ContactPhone1 { get; set; }
        public string ContactEmail1 { get; set; }
        public string ContactMobile1 { get; set; }
        public string ContactRemarks1 { get; set; }
        public string ContactName2 { get; set; }
        public string Designation2 { get; set; }
        public string ContactPhone2 { get; set; }
        public string ContactEmail2 { get; set; }
        public string ContactMobile2 { get; set; }
        public string ContactRemarks2 { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<DdblockedSupplier> DdblockedSupplier { get; set; }
        public virtual ICollection<DdsupplierDomain> DdsupplierDomain { get; set; }
        public virtual ICollection<DdsupplierItem> DdsupplierItem { get; set; }
    }
}
