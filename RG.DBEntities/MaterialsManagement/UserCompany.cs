using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class UserCompany
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CompanyId { get; set; }
    }
}
