using System;

namespace RG.DBEntities
{
    public class DefaultTableProperties
    {
        public virtual bool IsActive { get; set; }
        public virtual bool IsRemoved { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int? LastModifiedBy { get; set; }
        public virtual DateTime? LastModifiedDate { get; set; }
    }
}
