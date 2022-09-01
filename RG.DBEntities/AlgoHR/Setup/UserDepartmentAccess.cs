using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class UserDepartmentAccess
    {
        public int ID { get; set; }
        public int CA_UserID { get; set; }
        public int Embro_CompanyID { get; set; }
        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public int SectionID { get; set; }

    }
}
