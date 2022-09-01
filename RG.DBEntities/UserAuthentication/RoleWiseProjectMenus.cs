using RG.DBEntities;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.UserAuthentication
{
    public class RoleWiseProjectMenus : DefaultTableProperties
    {
        [Key]
        public int RoleWiseMenuID { get; set; }

        public int CompanyID { get; set; }
        public int ProjectRoleID { get; set; }
        public int ProjectMenuID { get; set; }
        public int AccessabilityID { get; set; }
    }
}