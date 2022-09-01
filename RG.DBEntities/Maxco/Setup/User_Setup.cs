using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class User_Setup
    {
        public short ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte DomainID { get; set; }
        public byte Status { get; set; }
        public int? SubDomainID { get; set; }
        public long? CompanyID { get; set; }
        public bool? Login { get; set; }
        public short? UserLanguageID { get; set; }
        public bool? LoggingStatus { get; set; }
        public string FullName { get; set; }
        public int? BusinessID { get; set; }
        public string CurrentIP { get; set; }
        public string UserCode { get; set; }
        public byte? UserGroupID { get; set; }
    }
}
