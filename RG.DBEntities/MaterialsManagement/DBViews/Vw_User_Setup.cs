using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.DBViews
{
    public class Vw_User_Setup
    {
        public Int16 ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte DomainID { get; set; }
        public byte Status { get; set; }
        public int SubDomainID { get; set; }
        public long CompanyID { get; set; }
        public Boolean Login { get; set; }
        public Int16 UserLanguageID { get; set; }
        public Boolean LoggingStatus { get; set; }
        public string FullName { get; set; }
        public int BusinessID { get; set; }
        public string CurrentIP { get; set; }
        public string UserCode { get; set; }
        public byte UserGroupID { get; set; }
    }
}
