using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class UserSetup
    {
        public UserSetup()
        {
            LcMcMasterChild = new HashSet<LC_MC_MASTER_CHILD>();
        }

        public short Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte DomainId { get; set; }
        public byte Status { get; set; }
        public int? SubDomainId { get; set; }
        public long? CompanyId { get; set; }
        public bool? Login { get; set; }
        public short? UserLanguageId { get; set; }
        public bool? LoggingStatus { get; set; }
        public string FullName { get; set; }
        public int? BusinessId { get; set; }
        public string CurrentIp { get; set; }
        public string UserCode { get; set; }
        public byte? UserGroupId { get; set; }

        public virtual DomainSetup Domain { get; set; }
        public virtual ICollection<LC_MC_MASTER_CHILD> LcMcMasterChild { get; set; }
    }
}
