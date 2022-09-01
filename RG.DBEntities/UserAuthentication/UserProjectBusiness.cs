using RG.DBEntities;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.UserAuthentication
{
    public class UserProjectBusiness : DefaultTableProperties
    {
        [Key]
        public int UserProjectBusinessID { get; set; }

        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public int ProjectID { get; set; }
        public int BusinessID { get; set; }
    }
}